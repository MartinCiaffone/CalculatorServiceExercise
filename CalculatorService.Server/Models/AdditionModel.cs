using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace CalculatorService.Server.Models
{

    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class AdditionModel
    {

        private int[] addendsField;

        [XmlElement("Addends")]
        [JsonPropertyName("Addends")] // Keep PascalCase.
        public int[] Addends
        {
            get
            {
                return this.addendsField;
            }
            set
            {
                this.addendsField = value;
            }
        }
    }


}

