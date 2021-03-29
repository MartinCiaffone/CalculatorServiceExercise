using System.Text.Json.Serialization;

namespace CalculatorService.Server.Models
{
    public class JournalModel
    {
        [JsonPropertyName("Id")] // Keep PascalCase.
        public string Id { get; set; }
    }
}
