﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PodilskyNVK.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Потрібно поле 'Адреса електронної пошти'")]
        [Display(Name = "Адреса електронної пошти")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Код")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Запам'ятати браузер?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "Потрібно поле 'Адреса електронної пошти'")]
        [Display(Name = "Адреса електронної пошти")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Потрібно поле 'Адреса електронної пошти'")]
        [Display(Name = "Адреса електронної пошти")]
        [EmailAddress(ErrorMessage = "Поле 'Адреса електронної пошти' не містить допустиму адресу електроної пошти.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Потрібно поле 'Пароль'")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запам'ятати мене")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Потрібно поле 'Адреса електронної пошти'")]
        [EmailAddress(ErrorMessage = "Поле 'Адреса електронної пошти' не містить допустиму адресу електроної пошти.")]
        [Display(Name = "Адреса електронної пошти")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Потрібно поле 'Пароль'")]
        [StringLength(100, ErrorMessage = "Значення {0} має містити не меньше {2} символів.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтведження пароля")]
        [Compare("Password", ErrorMessage = "Пароль і його підтвердження не співпадають.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Адреса електронної пошти")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значення {0} має містити не меньше {2} символів.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтведження пароля")]
        [Compare("Password", ErrorMessage = "Пароль і його підтвердження не співпадають.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Пошта")]
        public string Email { get; set; }
    }
}
