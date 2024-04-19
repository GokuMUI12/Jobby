namespace Core.Entities
{
    public class Offer : BaseEntity
    {
        public Offer()
        {

        }

        public Offer(int expectedDaysCompletion, int amount, string email, string message, int jobId)
        {
            Created = DateTime.UtcNow;
            ExpectedDaysCompletion = expectedDaysCompletion;
            Amount = amount;
            Email = email;
            Message = message;
            JobId = jobId;
        }

        public DateTime Created { get; set; }
        public int ExpectedDaysCompletion { get; set; }
        public int Amount { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }

    }
}
