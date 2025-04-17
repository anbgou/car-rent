
namespace CarRentalPlatform.Entities
{
    public enum CarStatus { Available, Rented, Unavailable }

    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string BodyType { get; set; }
        public int Mileage { get; set; }
        public string FuelType { get; set; }
        public string LicensePlate { get; set; }
        public string PhotoUrl { get; set; }
        public CarStatus Status { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }

        public ICollection<Rental> Rentals { get; set; }
        public ICollection<Insurance> Insurances { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
