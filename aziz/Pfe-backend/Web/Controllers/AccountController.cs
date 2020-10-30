using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Domain.Entities;
using Data;
using System.Web.Http.Cors;
using Web.Manager;
using Web.Models;
using System.Text;

namespace Web.Controllers
{
  // [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/users")]
    public class AccountController : ApiController
    {
        private PfeContext db = new PfeContext();
        //        [Route("api/User/Register")]
        //        [HttpPost]
        //        [AllowAnonymous]
        //        public IdentityResult Register(AccountModel model)
        //        {
        //            var userStore = new UserStore<ApplicationUser>(new PfeContext());
        //            var manager = new UserManager<ApplicationUser>(userStore);
        //            var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
        //            user.FirstName = model.FirstName;
        //            user.LastName = model.LastName;
        //            manager.PasswordValidator = new PasswordValidator
        //            {
        //                RequiredLength = 3
        //            };
        //            IdentityResult result = manager.Create(user, model.Password);
        //            return result;
        //        }
        //        [Route("api/GetUserClaims")]
        //        [HttpGet]

        //        public AccountModel GetUserClaims()
        //        {
        //            var identityClaims = (ClaimsIdentity)User.Identity;
        //            IEnumerable<Claim> claims = identityClaims.Claims;
        //            AccountModel model = new AccountModel()
        //            {
        //                UserName = identityClaims.FindFirst("UserName").Value,
        //                Email = identityClaims.FindFirst("Email").Value,
        //                FirstName = identityClaims.FindFirst("FirstName").Value,
        //                LastName = identityClaims.FindFirst("LastName").Value,
        //                LoggedOn = identityClaims.FindFirst("LoggedOn").Value
        //            };
        //            return model;
        //        }

        //    }
        //}
        [Route("register")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Register(User model)
        {
            if (this.UniqueEmailAndUsername(model.Email, model.UserName) == null)
            {
                string password = BCrypt.Net.BCrypt.HashPassword(model.Password);

                model.Password = password;
                var token = GenerateToken(8);

                model.Token = token;
                model.Enabled = false;
                model.AccessFailCount = 0;
                model.Role = "user";
                model.LockoutDateUtc = DateTime.Now;
                model.EmailConfirmed = false;

                db.Users.Add(model);
                db.SaveChanges();
                EmailManager mailer = new EmailManager();
                var res = mailer.SendMsg1(model.Email, model.Token, model.UserID);

                return Ok(new { created = "success", status = 200 });
            }

            var error = new
            {
                created = "error",
                error = this.UniqueEmailAndUsername(model.Email, model.UserName),
                status = 404
            };
            return Json(error);
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Login(User user)
        {
            var userData = db.Users.Where(u => u.Email.Equals(user.Email)).FirstOrDefault();
            if (userData != null)
            {
                if (BCrypt.Net.BCrypt.Verify(user.Password, userData.Password))
                {
                    IAuthContainerModel model = GetJWTContainerModel(userData.FirstName, userData.LastName, userData.UserName, userData.Email, userData.UserID, userData.Role);
                    IAuthService authService = new JWTService(model.SectretKey);
                    string token = authService.GenerateToken(model);
                    var connected = new
                    {
                        access_token = token,
                        enb = userData.Enabled,
                        attr = userData.EmailConfirmed,
                        fail = userData.AccessFailCount
                    };

                    return Json(connected);

                }
                return Json(new { error = "password" });
            }
            return Json(new { error = "email" });
        }

        [Route("verify")]
        [HttpGet]
        public IHttpActionResult VerifyAccount(string t, int i)
        {
            var userData = db.Users.Where(u => u.UserID == i).FirstOrDefault();
            if (userData != null)
            {
                if (userData.Token.Equals(""))
                {
                    return Json(new { error = "enabled", status = 403 });
                }
                if (userData.Token.Equals(t))
                {
                    userData.Token = "";
                    userData.Enabled = true;
                    db.SaveChanges();

                    IAuthContainerModel model = GetJWTContainerModel(userData.FirstName, userData.LastName, userData.UserName, userData.Email, userData.UserID, userData.Role);
                    IAuthService authService = new JWTService(model.SectretKey);
                    string accessToken = authService.GenerateToken(model);
                    var connected = new
                    {
                        access_token = accessToken,
                        enb = userData.Enabled,
                        attr = userData.EmailConfirmed,
                        fail = userData.AccessFailCount
                    };

                    return Json(connected);
                }
                else
                {
                    return Json(new { error = "token", status = 404 });
                }
            }
            return Json(new { error = "userId", status = 404 });
        }

        [Route("send")]
        [HttpGet]
        public IHttpActionResult SendTest()
        {
            var userId = 18;
            var User = db.Users.Where(u => u.UserID == userId).FirstOrDefault();
            if (User != null)
            {
                EmailManager mailer = new EmailManager();
                var res = mailer.SendMsg1(User.Email, User.Token, User.UserID);
                return Json(new { error = "sent" });
            }

            return Json(new { error = "fatal error" });
        }

        private string GenerateToken(int length)
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }

        private string UniqueEmailAndUsername(string email, string username)
        {
            var user = db.Users.Where(x => x.Email.Equals(email) || x.UserName.Equals(username)).FirstOrDefault();
            if (user != null)
            {
                //Username Or Password Already Exists
                if (user.Email.Equals(email))
                {
                    return "email";
                }
                return "username";
            }

            return null;
        }

        private static JWTContainerModel GetJWTContainerModel(string name, string last, string username, string email, int id, string role)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {       
                    new Claim(ClaimTypes.Name, name + ","+ last),
                    new Claim(ClaimTypes.Surname, username),
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                    new Claim(ClaimTypes.Role, role)
                }
            };
        }
    }
}