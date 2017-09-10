using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimOnline.Web.Models
{
    public class AgentRegisterViewModel
    {
        [Display(Name = "Tài khoản đăng nhập")]
        [Required(ErrorMessage = "Bạn chưa nhập tài khoản đăng nhập")]
        public string UserName { set; get; }

        [Display(Name = "Địa chỉ Email")]
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ email.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ, vui lòng kiểm tra lại.")]
        public string Email { set; get; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu.")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải ít nhất là {0} ký tự.")]
        public string PassWord { set; get; }

        public string AgentId { set; get; }

        [Display(Name="Tên đại lý")]
        [Required(ErrorMessage = "Bạn chưa nhập tên đại lý.")]
        public string Name { set; get; }

        [Display(Name = "Hotline")]
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại hotline.")]
        public string Hotline { set; get; }

        public string Address { set; get; }

        public DateTime? CreateDate { set; get; }

        public string CreateBy { set; get; }

        public DateTime? UpdateDate { set; get; }

        public string UpdateBy { set; get; }

        public bool Status { set; get; }

        public int? DisplayOrder { set; get; }
    }
}