namespace RentalManagementSystem.Models
{
    public class UtilityProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UtilityModel> Utilities { get; set; }
        public List<PropertyModel> Properties { get; set; }
    }
}
