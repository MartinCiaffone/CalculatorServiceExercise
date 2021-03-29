using System.Text.Json.Serialization;

namespace CalculatorService.Server.Models
{
    public class DivideResultModel
    {
        [JsonPropertyName("Quotient")] // Keep PascalCase.
        public int Quotient { get; set; }

        [JsonPropertyName("Remainder")] // Keep PascalCase.
        public int Remainder { get; set; }

        public void SetQuotientAndRemainder((int, int) t) //Calculator returns a tuple <int,in> for Division.
        {
            Quotient = t.Item1;
            Remainder = t.Item2;
        }
    }
}
