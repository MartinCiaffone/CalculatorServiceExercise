using System.Text.Json.Serialization;

namespace CalculatorService.ClientB.Models
{
    public class SubtractModel
    {
        [JsonPropertyName("Minuend")] // Keep PascalCase.
        public int Minuend { get; set; }
        [JsonPropertyName("Subtrahend")] // Keep PascalCase.
        public int Subtrahend { get; set; }
    }
}
