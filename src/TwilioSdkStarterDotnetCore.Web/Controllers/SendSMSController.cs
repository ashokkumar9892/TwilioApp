using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using TwilioSdkStarterDotnetCore.Web.Models;

namespace TwilioSdkStarterDotnetCore.Web.Controllers
{
    public class SendSMSController : Controller
    {
        private readonly TwilioAccount _twilioAccount;
        private readonly string authToken = "2010e55534c3ad56daee55b300fb1033";

        public SendSMSController(IOptions<TwilioAccount> twilioAccount)
        {
            if (twilioAccount == null)
            {
                throw new ArgumentNullException(nameof(twilioAccount));
            }
            _twilioAccount = twilioAccount.Value;
        }

        // For Text SMS
        public string SendTextSMS(string mobnumber, string text)
        {
            TwilioClient.Init(_twilioAccount.AccountSid, authToken);

            var message = MessageResource.Create(
                body: text,
                from: new Twilio.Types.PhoneNumber("+19592071545"),
                to: new Twilio.Types.PhoneNumber("+1" + mobnumber)
            );
            return "Message Sent to Mobile : " + mobnumber;
        }

        // For whatsapp
        public string SendWhatsappMsg()
        {
            TwilioClient.Init(_twilioAccount.AccountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("whatsapp:+919458412124"));
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
            messageOptions.Body = "Your appointment sample msg";

            var message = MessageResource.Create(messageOptions);
            return "Whatsapp message Sent to Mobile";
        }
    }
}
