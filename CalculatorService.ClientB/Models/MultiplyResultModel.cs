using System.Text.Json.Serialization;

namespace CalculatorService.ClientB.Models
{
    public class MultiplyResultModel
    {
        [JsonPropertyName("Product")] // Keep PascalCase.
        public int Product { get; set; }
    }
}
