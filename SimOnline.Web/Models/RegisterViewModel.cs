using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimOnline.Web.Models
{
    public class RegistersViewModel
    { 
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage ="Vui nhập đầy đủ họ tên")]
        public string FullName { set; get; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn chưa nhập tên đăng nhập")]
        public string UserName { set; get; }

        [Display(Name = "Địa chỉ Email")]
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ email.")]
        [EmailAddress(ErrorMessage ="Email không hợp lệ, vui lòng kiểm tra lại.")]
        public string Email { set; get; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu.")]
        [MinLength(6, ErrorMessage ="Mật khẩu phải ít nhất là {0} ký tự.")]
        public string PassWord { set; get; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        public string PhoneNumber { set; get; }

        [Display(Name = "Địa chỉ")]
        public string Address { set; get; }
    }
}