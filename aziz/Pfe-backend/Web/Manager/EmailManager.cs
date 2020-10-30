using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Web.Manager
{
    public class EmailManager
    {
        public async Task<IHttpActionResult> SendMsg1(string toEmail, string token, int id)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("no-reply@school.tn", "Equipe Scolarité");
            var to = new List<EmailAddress>();
            to.Add(new EmailAddress(toEmail));
            string body = "<a href='https://localhost:44325/api/users/verify?t=" + token + "&i=" + id + "' >Link</a>";
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, "Email Verification", "", body, false);

            try
            {
                var response = await client.SendEmailAsync(msg);
                return (null);
                //return true;
            }
            catch (Exception)
            {
                return null;
            }



        }

    }
}