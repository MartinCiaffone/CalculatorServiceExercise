using System.Text.Json.Serialization;

namespace CalculatorService.ClientB.Models
{
    public class DivideResultModel
    {
        [JsonPropertyName("Quotient")] // Keep PascalCase.
        public int Quotient { get; set; }
        [JsonPropertyName("Remainder")] // Keep PascalCase.
        public int Remainder { get; set; }
    }
}
