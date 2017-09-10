using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimOnline.Web.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Vui nhập đầy đủ họ tên")]
        public string FullName { set; get; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn chưa nhập tên đăng nhập")]
        public string UserName { set; get; }

        [Display(Name = "Địa chỉ Email")]
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ email.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ, vui lòng kiểm tra lại.")]
        public string Email { set; get; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu.")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải ít nhất là {0} ký tự.")]
        public string PassWord { set; get; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        public string PhoneNumber { set; get; }

        [Display(Name = "Địa chỉ")]
        public string Address { set; get; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [MinLength(6, ErrorMessage = "Mật khẩu phải ít nhất {1} ký tư.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu mới")]
        [Compare("Password", ErrorMessage = "Mật khẩu nhập lại không trùng khớp.")]
        public string ConfirmPassword { get; set; }

        public string UserId { get; set; }

        public string Code { get; set; }
    }
}