using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace LostAndFound.Pages
{
    public class LoginModel : PageModel
    {
        private readonly EmailService _emailService;

        // 修改字典结构，存储验证码和过期时间
        private static readonly Dictionary<string, CodeInfo> VerificationCodes = new Dictionary<string, CodeInfo>();

        public LoginModel(EmailService emailService)
        {
            _emailService = emailService;
        }

        [BindProperty]
        [Required(ErrorMessage = "邮箱不能为空")]
        [EmailAddress(ErrorMessage = "邮箱格式不正确")]
        [RegularExpression(@"^.+@mails\.jlu\.edu\.cn$", ErrorMessage = "必须使用@mails.jlu.edu.cn后缀的邮箱")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "验证码不能为空")]
        public string VerificationCode { get; set; }

        // 添加验证码信息类
        private class CodeInfo
        {
            public string Code { get; set; }
            public DateTime ExpirationTime { get; set; }
        }

        public IActionResult OnGet()
        {
//#if DEBUG
//            HttpContext.Session.SetString("Email", "test@mails.jlu.edu.cn");
//            return RedirectToPage("/Index");
//#endif


            if (HttpContext.Session.GetString("Email") != null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostSendCodeAsync()
        {
            ModelState.Remove(nameof(VerificationCode));

            if (!ModelState.IsValid)
            {
                return Page();
            }

            string code = GenerateVerificationCode();
            VerificationCodes[Email] = new CodeInfo
            {
                Code = code,
                ExpirationTime = DateTime.Now.AddMinutes(5)
            };

            bool sent = _emailService.SendVerificationCode(Email, code);

            if (sent)
            {
                ViewData["Message"] = "验证码已经发送，请查收邮箱！";
                return Page();
            }
            else
            {
                ModelState.AddModelError("", "验证码发送失败，请稍后再试。");
                return Page();
            }
        }

        public IActionResult OnPostVerifyCode()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // 验证时检查验证码和过期时间
            if (VerificationCodes.TryGetValue(Email, out var codeInfo) &&
                codeInfo.Code == VerificationCode &&
                DateTime.Now <= codeInfo.ExpirationTime)
            {
                HttpContext.Session.SetString("Email", Email);
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError("", "验证码不正确或已过期。");
                return Page();
            }
        }

        private string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}
