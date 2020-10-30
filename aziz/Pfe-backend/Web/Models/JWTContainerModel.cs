using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Web.Models
{
    public class JWTContainerModel : IAuthContainerModel
    {
        public string SectretKey { get; set; } = "qeFJ3QHNTZlo5nMgQyhdhuJlufb8yIwQQjsyoamSAQTFATHCgSUiuv==";
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;
        public int ExpireMinutes { get; set; } = 240; //4 heurs
        public Claim[] Claims { get; set; }


    }
}