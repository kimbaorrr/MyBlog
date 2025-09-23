using MyBlog.Models;
using MyBlog.Services.Interfaces;
using Newtonsoft.Json;

namespace MyBlog.Services
{
    public class CaptchaService : ICaptchaService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public CaptchaService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HCaptchaResponse> ValidateHCaptcha(string token)
        {
            string secretKey = this._configuration["Captcha:HCaptcha:SecretKey"] ?? string.Empty;
            string verifyUrl = this._configuration["Captcha:HCaptcha:VerifyUrl"] ?? string.Empty;

            HttpClient client = this._httpClientFactory.CreateClient();

            FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("secret", secretKey),
                new KeyValuePair<string, string>("response", token)
            });

            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            var response = await client.PostAsync(verifyUrl, content, cts.Token);

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<HCaptchaResponse>(json) ?? new HCaptchaResponse() { Success = false };

            return result;
        }
    }
}
