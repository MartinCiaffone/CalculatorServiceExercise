using System.Text.Json.Serialization;

namespace CalculatorService.ClientB.Models
{
    public class JournalModel
    {
        [JsonPropertyName("Id")] // Keep PascalCase.
        public string Id { get; set; }
    }
}
