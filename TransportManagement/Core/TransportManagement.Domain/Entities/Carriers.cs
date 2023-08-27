using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportManagement.Entities.Entities
{
    
    public class Carriers : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string CarrierName { get; set; }

        [Required]
        public bool CarrierIsActive { get; set; }

        [Required]
        public int CarrierPlusDesiCost { get; set; }
        public ICollection<CarrierConfigurations> CarrierConfigurations{ get; set; }
    }
}
