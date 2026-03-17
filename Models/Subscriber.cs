namespace Quote_genarator.Models
{
    public class Subscriber
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public bool IsSubscribed { get; set; } = false;

        public bool IsConfirmed { get; set; } = false;

        public string ConfirmationToken { get; set; }

        public DateTime SubscribedAt { get; set; } = DateTime.UtcNow;
    }
}
