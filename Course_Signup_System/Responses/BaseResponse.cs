using System.Text.Json.Serialization;

namespace Course_Signup_System.Responses
{
    public abstract class BaseResponse
    {
        [JsonIgnore]
        public bool Success { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Error { get; set; }
    }
}
