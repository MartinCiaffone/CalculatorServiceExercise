using System.Text.Json.Serialization;

namespace CalculatorService.ClientB.Models
{
    public class SubtractResultModel
    {
        [JsonPropertyName("Difference")] // Keep PascalCase.
        public int Difference { get; set; }
    }
}
