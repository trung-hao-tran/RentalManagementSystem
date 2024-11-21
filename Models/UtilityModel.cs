namespace RentalManagementSystem.Models
{
    public class UtilityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public int UtilityProfileId { get; set; }
        public UtilityProfile? UtilityProfile { get; set; }

    }
}
