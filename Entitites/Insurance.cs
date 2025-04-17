using CarRentalPlatform.Entities;

namespace CarRentalPlatform.Entities
{
    public class Insurance
    {
        public int Id { get; set; }
        public string InsuranceType { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string InsuranceCompany { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
