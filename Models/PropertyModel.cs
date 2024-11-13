using System.Collections;

namespace RentalManagementSystem.Models
{
    public class PropertyModel
    {

        public int Id { get; set; }
        public required decimal Price { get; set; }
        public required string Number { get; set; }
        public List<RenterModel> Renters { get; set; } = [];
    }
}
