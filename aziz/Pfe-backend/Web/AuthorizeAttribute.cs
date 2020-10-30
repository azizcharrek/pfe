/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Web
{
    public class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        public string Permissions { get; set; }

        //private IAccountRepository AccountRepository { get; set; }

        private string[] permArray { get; set; }

        private string reqStatus { get; set; }

        public AuthorizeAttribute()
        {
            this.AccountRepository = new UserModel();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            base.AuthorizeCore(httpContext);

            if (Permissions != null)
            {
                permArray = Permissions.Trim().Split(' ');

                if (AccountRepository.isEnabled(httpContext.User.Identity.Name))
                {
                    this.reqStatus = "permission";
                    return AccountRepository.hasPermissions(permArray);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return AccountRepository.isEnabled(httpContext.User.Identity.Name);
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (this.reqStatus == "permission")
            {
                filterContext.Result = new RedirectResult(MvcApplication.eM.cause("no_permission", "redirect"));
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }*/