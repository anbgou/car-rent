using CarRentalPlatform.Entities;

namespace CarRentalPlatform.Entities
{
    public enum PaymentType { Reservation, Penalty, Refund }

    public class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public decimal Amount { get; set; }
        public PaymentType Type { get; set; }
        public DateTime Date { get; set; }
    }
}
