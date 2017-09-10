using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BotDetect.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using SimOnline.Common;
using SimOnline.Model.Models;
using SimOnline.Service;
using SimOnline.Web.App_Start;
using SimOnline.Web.Infrastructure.Extensions;
using SimOnline.Web.Models;

namespace SimOnline.Web.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private IAgentService _agentService;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, IAgentService agentService)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            this._agentService = agentService;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public AccountController()
        {
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [CaptchaValidation("CaptchaCode", "registerCaptcha", "Mã xác nhận không đúng!")]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userByEmail = await _userManager.FindByEmailAsync(model.Email);
                if (userByEmail != null)
                {
                    ModelState.AddModelError("email", "Email đã tồn tại");
                    return View(model);
                }
                var userByUserName = await _userManager.FindByNameAsync(model.UserName);
                if (userByUserName != null)
                {
                    ModelState.AddModelError("user", "Tài khoản đã tồn tại");
                    return View(model);
                }
                var user = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    EmailConfirmed = false,
                    BirthDay = DateTime.Now,
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address
                };

                var result = await _userManager.CreateAsync(user, model.PassWord);

                if (result.Succeeded)
                {
                    var adminUser = await _userManager.FindByEmailAsync(model.Email);
                    if (adminUser != null)
                        await _userManager.AddToRolesAsync(adminUser.Id, new string[] { "User" });

                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    var provider = new DpapiDataProtectionProvider("SimOnline");
                    UserManager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(provider.Create("EmailConfirmation"));
                    var token = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);

                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userID = user.Id, code = token }, protocol: Request.Url.Scheme);

                    string content = System.IO.File.ReadAllText(Server.MapPath("/assets/templates/confirm-email.html"));
                    content = content.Replace("{{UserName}}", adminUser.FullName);
                    content = content.Replace("{{Link}}", callbackUrl);

                    MailHelper.SendMail(adminUser.Email, "[Nhatsim.com] Kích hoạt tài khoản", content);

                    ViewData["SuccessMsg"] = "Đăng ký thành công";
                }
            }
            return View();
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

            var provider = new DpapiDataProtectionProvider("SimOnline");
            UserManager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(provider.Create("EmailConfirmation"));

            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        [HttpGet]
        public ActionResult RegisterAgent()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [CaptchaValidation("CaptchaCode", "registerCaptcha", "Mã xác nhận không đúng!")]
        public async Task<ActionResult> RegisterAgent(AgentRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userByEmail = await _userManager.FindByEmailAsync(model.Email);
                if (userByEmail != null)
                {
                    ModelState.AddModelError("email", "Email đã tồn tại");
                    return View(model);
                }
                var userByUserName = await _userManager.FindByNameAsync(model.UserName);
                if (userByUserName != null)
                {
                    ModelState.AddModelError("user", "Tài khoản đã tồn tại");
                    return View(model);
                }

                Agent newAgent = new Agent();
                model.AgentId = Guid.NewGuid().ToString();
                newAgent.UpdateRegisterAgent(model);
                var agentReturn = _agentService.Add(newAgent);
                _agentService.SaveChanges();

                var user = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    EmailConfirmed = false,
                    BirthDay = DateTime.Now,
                    Address = model.Address,
                    AgentID = agentReturn.AgentId
                };

                var result = await _userManager.CreateAsync(user, model.PassWord);

                if (result.Succeeded)
                {
                    var adminUser = await _userManager.FindByEmailAsync(model.Email);
                    if (adminUser != null)
                        await _userManager.AddToRolesAsync(adminUser.Id, new string[] { "User" });

                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    var provider = new DpapiDataProtectionProvider("SimOnline");
                    UserManager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(provider.Create("EmailConfirmation"));
                    var token = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);

                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userID = user.Id, code = token }, protocol: Request.Url.Scheme);

                    string content = System.IO.File.ReadAllText(Server.MapPath("/assets/templates/confirm-email.html"));
                    content = content.Replace("{{UserName}}", adminUser.FullName);
                    content = content.Replace("{{Link}}", callbackUrl);

                    MailHelper.SendMail(adminUser.Email, "[Nhatsim.com] Kích hoạt tài khoản", content);

                    ViewData["SuccessMsg"] = "Đăng ký thành công";
                }
            }
            return View();
        }


        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                var provider = new DpapiDataProtectionProvider("SimOnline");
                UserManager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(provider.Create("EmailConfirmation"));
                var token = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { UserId = user.Id, code = token }, protocol: Request.Url.Scheme);

                string content = System.IO.File.ReadAllText(Server.MapPath("/assets/templates/reset-password.html"));
                content = content.Replace("{{Link}}", callbackUrl);

                MailHelper.SendMail(model.Email, "[Nhatsim.com] Lấy lại mật khẩu", content);

                ViewData["SuccessMsg"] = "Đăng ký thành công";

                await UserManager.SendEmailAsync(user.Id, "Reset Password",
            "Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">link</a>");
                return View("ForgotPasswordConfirmation");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.UserId);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var provider = new DpapiDataProtectionProvider("SimOnline");
            UserManager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(provider.Create("EmailConfirmation"));
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            //AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}