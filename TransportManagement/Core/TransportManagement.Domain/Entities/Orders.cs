using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportManagement.Entities.Entities
{
    public class Orders : BaseEntity
    {

        [Required]
        public int OrderDesi{ get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public decimal OrderCarrierCost { get; set; }

        [Required]
        public int CarrierId { get; set; }

        [Required]
        [ForeignKey("CarrierId")]
        public Carriers Carrier{ get; set; }

    }
}
