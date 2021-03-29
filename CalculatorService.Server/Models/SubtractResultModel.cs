using System.Text.Json.Serialization;

namespace CalculatorService.Server.Models
{
    public class SubtractResultModel
    {
        [JsonPropertyName("Difference")] // Keep PascalCase.
        public int Difference { get; set; }
    }
}
