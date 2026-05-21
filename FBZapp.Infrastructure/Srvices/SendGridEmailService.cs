using FBZapp.Application.Interfaces;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FBZapp.Infrastructure.Services
{
    public class SendGridEmailService : IEmailService
    {
        public async Task SendComicSavedEmailAsync(string userEmail, string comicTitle)
        {
            string subject = "Comic saved successfully";
            string message = "You have saved '" + comicTitle + "' to your FBZapp account.";

            await SendEmailAsync(userEmail, subject, message);
        }

        public async Task SendComicFlaggedEmailAsync(string adminEmail, string comicTitle)
        {
            string subject = "Comic record flagged for review";
            string message = "The comic record '" + comicTitle + "' has been flagged and needs staff review.";

            await SendEmailAsync(adminEmail, subject, message);
        }

        private async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            string apiKey = ConfigurationManager.AppSettings["SendGridApiKey"];
            string fromEmail = ConfigurationManager.AppSettings["SendGridFromEmail"];

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException("SendGrid API key is missing in Web.config.");
            }

            if (string.IsNullOrWhiteSpace(fromEmail))
            {
                throw new InvalidOperationException("SendGrid sender email is missing in Web.config.");
            }

            if (string.IsNullOrWhiteSpace(toEmail))
            {
                throw new InvalidOperationException("Recipient email address is missing.");
            }

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", apiKey);

                string jsonBody =
                    "{"
                    + "\"personalizations\":[{"
                    + "\"to\":[{\"email\":\"" + EscapeJson(toEmail) + "\"}]"
                    + "}],"
                    + "\"from\":{\"email\":\"" + EscapeJson(fromEmail) + "\",\"name\":\"FBZapp\"},"
                    + "\"subject\":\"" + EscapeJson(subject) + "\","
                    + "\"content\":[{"
                    + "\"type\":\"text/plain\","
                    + "\"value\":\"" + EscapeJson(message) + "\""
                    + "}]"
                    + "}";

                HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                HttpResponseMessage response =
                    await client.PostAsync("https://api.sendgrid.com/v3/mail/send", content);

                if (!response.IsSuccessStatusCode)
                {
                    string responseText = await response.Content.ReadAsStringAsync();

                    throw new InvalidOperationException(
                        "SendGrid email failed. Status: "
                        + response.StatusCode
                        + ". Details: "
                        + responseText);
                }
            }
        }

        private string EscapeJson(string value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return value
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n");
        }
    }
}
