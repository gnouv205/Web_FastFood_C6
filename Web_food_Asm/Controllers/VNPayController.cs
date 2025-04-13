using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Web_food_Asm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VNPayController : ControllerBase
    {
        private readonly IConfiguration _config;
		public VNPayController(IConfiguration config) 
		{
			_config = config;
		}

		[HttpPost("create-payment")]
		public IActionResult CreatePaymentUrl([FromBody] VNPayPaymentRequest model)
		{
			var vnp_TmnCode = _config["VNPay:TmnCode"];
			var vnp_HashSecret = _config["VNPay:HashSecret"];
			var vnp_Url = _config["VNPay:PaymentUrl"];
			var vnp_ReturnUrl = _config["VNPay:ReturnUrl"];

			var time = DateTime.UtcNow.AddHours(7).ToString("yyyyMMddHHmmss");
			var orderId = DateTime.UtcNow.Ticks.ToString();

			var payParams = new SortedDictionary<string, string>
		{
			{ "vnp_Version", "2.1.0" },
			{ "vnp_Command", "pay" },
			{ "vnp_TmnCode", vnp_TmnCode },
			{ "vnp_Amount", (model.Amount * 100).ToString() }, // Số tiền nhân 100 (VNPay yêu cầu)
            { "vnp_CurrCode", "VND" },
			{ "vnp_TxnRef", orderId },
			{ "vnp_OrderInfo", model.OrderInfo },
			{ "vnp_OrderType", "other" },
			{ "vnp_Locale", "vn" },
			{ "vnp_ReturnUrl", vnp_ReturnUrl },
			{ "vnp_IpAddr", HttpContext.Connection.RemoteIpAddress?.ToString() },
			{ "vnp_CreateDate", time }
		};

			// Tạo query string
			var queryString = string.Join("&", payParams.Select(x => $"{x.Key}={Uri.EscapeDataString(x.Value)}"));

			// Tạo mã bảo mật (hash)
			var signData = string.Join("&", payParams.Select(x => $"{x.Key}={x.Value}"));
			var vnp_SecureHash = HmacSHA512(vnp_HashSecret, signData);

			// Thêm hash vào query string
			var paymentUrl = $"{vnp_Url}?{queryString}&vnp_SecureHash={vnp_SecureHash}";

			return Ok(new { PaymentUrl = paymentUrl });
		}

		private string HmacSHA512(string key, string data)
		{
			using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(key));
			var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
			return string.Concat(hash.Select(b => b.ToString("x2")));
		}

		[HttpGet("return")]
		public IActionResult PaymentReturn([FromQuery] Dictionary<string, string> queryParams)
		{
			var vnp_HashSecret = _config["VNPay:HashSecret"];

			// Lấy thông tin giao dịch từ query string
			var vnp_SecureHash = queryParams["vnp_SecureHash"];
			queryParams.Remove("vnp_SecureHash");

			var signData = string.Join("&", queryParams.OrderBy(x => x.Key).Select(x => $"{x.Key}={x.Value}"));
			var checkSum = HmacSHA512(vnp_HashSecret, signData);

			if (checkSum == vnp_SecureHash)
			{
				var status = queryParams["vnp_ResponseCode"] == "00" ? "Thành công" : "Thất bại";
				return Ok(new { Status = status, OrderId = queryParams["vnp_TxnRef"] });
			}
			else
			{
				return BadRequest("Chữ ký không hợp lệ");
			}
		}

	}

	public class VNPayPaymentRequest
	{
		public decimal Amount { get; set; }
		public string OrderInfo { get; set; }
	}
}

