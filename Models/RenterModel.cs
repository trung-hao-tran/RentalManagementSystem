namespace RentalManagementSystem.Models
{
    public class RenterModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public int PropertyId { get; set; }
        public PropertyModel? Property { get; set; }

    }
}
