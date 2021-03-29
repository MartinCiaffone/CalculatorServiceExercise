using System.Text.Json.Serialization;

namespace CalculatorService.Server.Models
{
    public class SquareRootModel
    {
        [JsonPropertyName("Number")] // Keep PascalCase.
        public int Number { get; set; }
    }
}
