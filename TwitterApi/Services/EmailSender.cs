using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using TwitterApi.Utilities;

namespace TwitterApi.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                            ILogger<EmailSender> logger)
        {
            Options = optionsAccessor.Value;
            _logger = logger;
        }

        public AuthMessageSenderOptions Options { get; }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            if (string.IsNullOrEmpty(Options.SendGridKey))
            {
                throw new Exception("Null SendGridKey");
            }

            await Execute(Options.SendGridKey, subject, htmlMessage, email);
        }

        public async Task Execute(string apiKey, string subject, string htmlMessage, string toEmail)
        {
            var client = new SendGridClient(apiKey);
            var message = new SendGridMessage
            {
                From = new EmailAddress("cr7.rouhbakhsh.7@gmail.com"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };
            message.AddTo(new EmailAddress(toEmail));

            message.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(message);

            _logger.LogInformation(response.IsSuccessStatusCode
                ? $"Email to {toEmail} queued successfully!"
                : $"Failure Email to {toEmail}");
        }
    }
}
