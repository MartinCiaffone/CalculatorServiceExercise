using System.Text.Json.Serialization;

namespace CalculatorService.ClientB.Models
{
    public class JournalResultModel
    {
        [JsonPropertyName("Operations")] // Keep PascalCase.
        public Operation[] Operations { get; set; }
    }

    public class Operation
    {
        [JsonPropertyName("Operation")] // Keep PascalCase.
        public string OperationName { get; set; }
        [JsonPropertyName("Calculation")] // Keep PascalCase.
        public string Calculation { get; set; }
        [JsonPropertyName("Date")] // Keep PascalCase.
        public string Date { get; set; }
    }

}
