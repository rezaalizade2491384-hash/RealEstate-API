using System.ComponentModel.DataAnnotations;

namespace RealEstate.Api.DTOs
{
    public class CreatePropertyDto
    {
        [Required(ErrorMessage = "عنوان ملک الزامی است")]
        [StringLength(200, ErrorMessage = "عنوان نمی‌تواند بیشتر از ۲۰۰ کاراکتر باشد")]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "توضیحات نمی‌تواند بیشتر از ۱۰۰۰ کاراکتر باشد")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "قیمت الزامی است")]
        [Range(0, double.MaxValue, ErrorMessage = "قیمت نمی‌تواند منفی باشد")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "آدرس الزامی است")]
        [StringLength(300, ErrorMessage = "آدرس نمی‌تواند بیشتر از ۳۰۰ کاراکتر باشد")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "مساحت الزامی است")]
        [Range(1, 10000, ErrorMessage = "مساحت باید بین ۱ تا ۱۰۰۰۰ متر مربع باشد")]
        public int Area { get; set; }

        [Required(ErrorMessage = "تعداد اتاق الزامی است")]
        [Range(0, 20, ErrorMessage = "تعداد اتاق باید بین ۰ تا ۲۰ باشد")]
        public int Bedrooms { get; set; }

        [Required(ErrorMessage = "تعداد سرویس بهداشتی الزامی است")]
        [Range(0, 10, ErrorMessage = "تعداد سرویس بهداشتی باید بین ۰ تا ۱۰ باشد")]
        public int Bathrooms { get; set; }
    }
}