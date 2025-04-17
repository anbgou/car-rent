using CarRentalPlatform.Entities;

namespace CarRentalPlatform.Entities
{
    public class Review
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public User Sender { get; set; }

        public int? ReceiverUserId { get; set; }
        public User ReceiverUser { get; set; }

        public int? CarId { get; set; }
        public Car Car { get; set; }

        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
