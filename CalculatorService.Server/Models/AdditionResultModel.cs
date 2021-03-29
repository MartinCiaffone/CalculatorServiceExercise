using System.Text.Json.Serialization;

namespace CalculatorService.Server.Models
{
    public class AdditionResultModel
    {
        [JsonPropertyName("Sum")] // Keep PascalCase.
        public int Sum { get; set; }
    }
}
