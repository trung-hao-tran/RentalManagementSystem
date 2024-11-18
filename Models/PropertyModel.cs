using System.Collections;

namespace RentalManagementSystem.Models
{
    public class PropertyModel
    {

        public int Id { get; set; }
        public required float Price { get; set; }
        public required int UnitNumber { get; set; }
        public required char BlockNumber { get; set; }
        public List<RenterModel> Renters { get; set; }
    }
}
