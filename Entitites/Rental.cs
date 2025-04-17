using CarRentalPlatform.Entities;

namespace CarRentalPlatform.Entities
{
    public enum RentalStatus { Pending, Confirmed, Completed }

    public class Rental
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int RenterId { get; set; }
        public User Renter { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public RentalStatus Status { get; set; }
    }
}
