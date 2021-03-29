using System.Text.Json.Serialization;

namespace CalculatorService.Server.Models
{
    public class ErrorResponseModel
    {
        [JsonPropertyName("ErrorCode")] // Keep PascalCase.
        public string ErrorCode { get; set; }
        [JsonPropertyName("ErrorStatus")] // Keep PascalCase.
        public int ErrorStatus { get; set; }
        [JsonPropertyName("ErrorMessage")] // Keep PascalCase.
        public string ErrorMessage { get; set; }
    }

}
