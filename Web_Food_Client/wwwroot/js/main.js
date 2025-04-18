// Function để trigger click trên input file
window.triggerFileInput = function (element) {
    element.click();
};

// Function khởi tạo slider (sử dụng thư viện noUiSlider)
window.initSlider = function () {
    const slider = document.getElementById('sl2');
    if (slider) {
        noUiSlider.create(slider, {
            start: [20, 80],
            connect: true,
            range: {
                'min': 0,
                'max': 100
            }
        });
    }
};

// Function thay đổi màu RGB
window.RGBChange = function (r, g, b) {
    const rgbElement = document.getElementById('RGB');
    if (rgbElement) {
        rgbElement.style.background = `rgb(${r},${g},${b})`;
    }
};

// Function scroll to top
window.scrollToTop = function () {
    window.scrollTo({
        top: 0,
        behavior: 'smooth'
    });
};

// Tự động hiển thị nút scroll-to-top khi cuộn
window.toggleScrollButton = function () {
    const scrollButton = document.querySelector('.scroll-to-top');
    if (scrollButton) {
        if (window.pageYOffset > 300) {
            scrollButton.classList.add('visible');
        } else {
            scrollButton.classList.remove('visible');
        }
    }
};

// Thêm event listener khi trang load xong
document.addEventListener('DOMContentLoaded', function () {
    // Khởi tạo slider
    if (typeof noUiSlider !== 'undefined') {
        initSlider();
    }

    // Thêm sự kiện scroll
    window.addEventListener('scroll', toggleScrollButton);
});