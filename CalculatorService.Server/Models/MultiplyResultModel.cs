using System.Text.Json.Serialization;

namespace CalculatorService.Server.Models
{
    public class MultiplyResultModel
    {
        [JsonPropertyName("Product")] // Keep PascalCase.
        public int Product { get; set; }
    }
}
