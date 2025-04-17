using Microsoft.EntityFrameworkCore;
using CarRentalPlatform.Data;
using CarRentalPlatform.Entities;

class Program
{
    static void Main()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CRDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        optionsBuilder.UseSqlServer(connectionString);

        using var context = new AppDbContext(optionsBuilder.Options);

        context.Database.EnsureCreated();

        if (!context.Users.Any())
        {
            var owner = new User
            {
                FullName = "Олег Власник",
                Email = "owner@example.com",
                Type = UserType.Owner,
                Rating = 4.9,
                DriverLicenseNumber = "AB123456"
            };

            var renter = new User
            {
                FullName = "Ірина Орендар",
                Email = "renter@example.com",
                Type = UserType.Renter,
                Rating = 4.5,
                DriverLicenseNumber = "CD654321"
            };

            var car = new Car
            {
                Make = "Toyota",
                Model = "Corolla",
                Year = 2020,
                BodyType = "Седан",
                Mileage = 45000,
                FuelType = "Бензин",
                LicensePlate = "AA1234BB",
                Owner = owner,
                PhotoUrl = "https://example.com/car.jpg",
                Status = CarStatus.Available
            };

            var rental = new Rental
            {
                Car = car,
                Renter = renter,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(3),
                TotalPrice = 1500,
                Status = RentalStatus.Confirmed
            };

            var payment = new Payment
            {
                User = renter,
                Amount = 1500,
                Type = PaymentType.Reservation,
                Date = DateTime.Now
            };

            var review = new Review
            {
                Sender = renter,
                ReceiverUser = owner,
                Car = car,
                Rating = 5,
                Comment = "Все пройшло чудово!"
            };

            var insurance = new Insurance
            {
                Car = car,
                InsuranceType = "КАСКО",
                ExpiryDate = DateTime.Today.AddYears(1),
                InsuranceCompany = "Страхова Україна"
            };

            context.Users.AddRange(owner, renter);
            context.Cars.Add(car);
            context.Rentals.Add(rental);
            context.Payments.Add(payment);
            context.Reviews.Add(review);
            context.Insurances.Add(insurance);

            context.SaveChanges();

            Console.WriteLine("Дані успішно додано!");
        }

        Console.WriteLine("Список авто:");
        foreach (var car in context.Cars.Include(c => c.Owner))
        {
            Console.WriteLine($"- {car.Make} {car.Model} ({car.LicensePlate}) - Власник: {car.Owner.FullName}");
        }
    }
}
