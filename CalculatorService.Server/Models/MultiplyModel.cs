using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace CalculatorService.Server.Models
{
    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class MultiplyModel
    {
        private int[] factorsField;

        [XmlElement("Factors")]
        [JsonPropertyName("Factors")] // Keep PascalCase.
        //public int[] Factors { get; set; }
        public int[] Factors
        {
            get
            {
                return this.factorsField;
            }
            set
            {
                this.factorsField = value;
            }
        }
    }
}
