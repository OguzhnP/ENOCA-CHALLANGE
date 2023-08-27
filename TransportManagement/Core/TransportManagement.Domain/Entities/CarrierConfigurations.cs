using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TransportManagement.Entities.Entities
{
    public class CarrierConfigurations : BaseEntity
    {
        [Required]
        public int CarrierMaxDesi { get; set; }

        [Required]
        public int CarrierMinDesi { get; set; }

        [Required]
        public decimal CarrierCost { get; set; }

        [Required]
        public int CarrierId { get; set; }

        [Required]
        [ForeignKey("CarrierId")]
        [JsonIgnore]
        public Carriers Carrier { get; set; }

    }
}
