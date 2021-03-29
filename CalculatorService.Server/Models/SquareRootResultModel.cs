using System.Text.Json.Serialization;

namespace CalculatorService.Server.Models
{
    public class SquareRootResultModel
    {
        [JsonPropertyName("Square")] // Keep PascalCase.
        public int Square { get; set; }
    }
}
