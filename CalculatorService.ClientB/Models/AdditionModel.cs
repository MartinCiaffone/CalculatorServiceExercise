using System.Text.Json.Serialization;

namespace CalculatorService.ClientB.Models
{
    public class AdditionModel
    {
        [JsonPropertyName("Addends")] // Keep PascalCase.
        public int[] Addends { get; set; }
    }

}
