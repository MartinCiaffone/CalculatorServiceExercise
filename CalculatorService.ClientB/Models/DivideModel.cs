using System.Text.Json.Serialization;

namespace CalculatorService.ClientB.Models
{
    public class DivideModel
    {
        [JsonPropertyName("Dividend")] // Keep PascalCase.
        public int Dividend { get; set; }
        [JsonPropertyName("Divisor")] // Keep PascalCase.
        public int Divisor { get; set; }
    }
}
