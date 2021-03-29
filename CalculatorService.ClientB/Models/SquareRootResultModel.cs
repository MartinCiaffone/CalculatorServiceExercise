using System.Text.Json.Serialization;

namespace CalculatorService.ClientB.Models
{
    public class SquareRootResultModel
    {
        [JsonPropertyName("Square")] // Keep PascalCase.
        public int Square { get; set; }
    }
}
