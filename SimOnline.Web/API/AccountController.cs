using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using SimOnline.Web.App_Start;
using System.Web.Http.Cors;
using SimOnline.Web.Models;
using Microsoft.Owin.Security.DataProtection;
using SimOnline.Model.Models;
using SimOnline.Common;
namespace SimOnline.Web.Api
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
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
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<HttpResponseMessage> Login(HttpRequestMessage request, string userName, string password, bool rememberMe)
        {
            if (!ModelState.IsValid)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(userName, password, rememberMe, shouldLockout: false);
            return request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("logout")]
        public HttpResponseMessage Logout(HttpRequestMessage request)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return request.CreateResponse(HttpStatusCode.OK, new { success = true });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("forgot-password")]
        public async Task<IHttpActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return Ok();
                }

                var provider = new DpapiDataProtectionProvider("SimOnline");
                UserManager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(provider.Create("EmailConfirmation"));
                var token = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                //token = HttpUtility.UrlDecode(token);
                System.Web.Mvc.UrlHelper helper = new System.Web.Mvc.UrlHelper();
                var callbackUrl = "http://localhost:49865/Account/ResetPassword?UserId="+ user.Id + "&code=" + token;
                
                string content = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/assets/templates/reset-password.html"));
                content = content.Replace("{{Link}}", callbackUrl);

                MailHelper.SendMail(model.Email, "[Nhatsim.com] Lấy lại mật khẩu", content);

                await UserManager.SendEmailAsync(user.Id, "Reset Password",
            "Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">link</a>");
                return Ok();
            }

            // If we got this far, something failed, redisplay form
            return BadRequest(ModelState);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("reset-password")]
        public async Task<IHttpActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await UserManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return Ok();
            }
            var provider = new DpapiDataProtectionProvider("SimOnline");
            UserManager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(provider.Create("EmailConfirmation"));
            var token = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
            var code = HttpUtility.UrlEncode(model.Code);
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            return Ok();
        }
    }
}
