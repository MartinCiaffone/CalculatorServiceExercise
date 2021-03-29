using System.Text.Json.Serialization;

namespace CalculatorService.ClientB.Models
{
    public class SquareRootModel
    {
        [JsonPropertyName("Number")] // Keep PascalCase.
        public int Number { get; set; }
    }
}
