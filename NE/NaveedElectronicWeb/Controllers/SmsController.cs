using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using NaveedElectronicWeb.Extensions;

namespace NaveedElectronicWeb.Controllers
{
    public class SmsController : TwilioController
    {
        [HttpGet]
        public ActionResult SendSms()
        {
            return View();
        }

        [HttpPost]
         public ActionResult SendSms(SMS sms)
        {
          var  phonenumber = sms.PhoneNumber.Trim();
            var accouutSid = TwilioConstants.ACCOUNTSID;
            var authToken = TwilioConstants.AUTHTOKEN;

            TwilioClient.Init(accouutSid, authToken);
            
            if(phonenumber.StartsWith("+923") && phonenumber.Length == 13)
            {
                var to = new PhoneNumber(phonenumber);
                var from = new PhoneNumber("+1413-923-6404");
                var message = MessageResource.Create(to: to, from: from, body: sms.Message);
                return Content(message.Sid);
            }
            else
            {
                return Content("<h1 class='text-danger'>Not a valid Number.</h1> <small>Please enter a valid number </small>");
            }
           
            
        }


    }

    public class SMS
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}