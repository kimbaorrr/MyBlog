using System.Text.Json.Serialization;

namespace MyBlog.Models
{
    public class CommonResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; } = false;
        [JsonPropertyName("challenge_ts")]
        public string ChallengeTS { get; set; } = string.Empty;
        [JsonPropertyName("hostname")]
        public string HostName { get; set; } = string.Empty;
        [JsonPropertyName("error-codes")]
        public string[] ErrorCodes { get; set; } = new string[] { };
    }
    public class HCaptchaResponse : CommonResponse
    {
        [JsonPropertyName("credit")]
        public bool? Credit { get; set; }
    }
}
