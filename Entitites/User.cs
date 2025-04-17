
namespace CarRentalPlatform.Entities
{
    public enum UserType { Owner, Renter }

    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
        public double Rating { get; set; }
        public string DriverLicenseNumber { get; set; }

        public ICollection<Car> Cars { get; set; }
        public ICollection<Rental> Rentals { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Review> SentReviews { get; set; }
        public ICollection<Review> ReceivedReviews { get; set; }
    }
}
