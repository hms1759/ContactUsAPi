using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using StartClassTest.ConfigModel;
using StartClassTest.IServices;
using StartClassTest.ViewModel;

namespace StartClassTest.Services
{
    public class ContactUsService : IContactUsService
    {

        private readonly EmailConfigSettings _emailConfig;
        public ContactUsService(IOptions<EmailConfigSettings> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }

        public async Task<bool> CreateContactus(ContactUsViewModel model)
        {
            if (model == null)
            throw new NotImplementedException();
            try { 
            var Subject = "Recieve Notification";

                string senderMessage = @$"<p>Dear {model.Name},</p>
                                <p>Your email has been sent to the admin,<br>
                                one of our staff will reach out to you via your email {model.Email}</p>";
                var adminMessage = @$"<p>Hi Admin </p>, 
                                    <p>{model.Name} has reachout via our contact us, below is the message :</p>
                                    <p>{model.Message}. </p>
                                    <p> Kindly  reach out to the customer via {model.Email}</p>";

            //mail to sender
            var sendermailmessage = new Message(new List<string> { model.Email }, Subject, senderMessage);
            var recievermailmessage = new Message(_emailConfig.MailTo.ToList(), Subject, adminMessage);
            var sendermail = await SendEmail(sendermailmessage);
            var recievermail = await SendEmail(recievermailmessage);
                if(!sendermail|| !recievermail)
                    return false;

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> SendEmail(Message message)
        {
            try
            {
                var emailMessage = new MimeMessage();

                //sender
                emailMessage.From.Add(new MailboxAddress(_emailConfig.DisplayName, _emailConfig.From));

                //receiver
                foreach (string mailAddress in message.To)
                    emailMessage.To.Add(MailboxAddress.Parse(mailAddress));

                //Add Content to Mime Message
                var content = new BodyBuilder();
                emailMessage.Subject = message.Subject;
                content.HtmlBody = message.Body;
                emailMessage.Body = content.ToMessageBody();

                //send email
                using var client = new MailKit.Net.Smtp.SmtpClient();

                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
