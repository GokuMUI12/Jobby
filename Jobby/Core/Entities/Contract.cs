namespace Core.Entities
{
    public class Contract
    {
        public Contract()
        {

        }

        public int Id { get; set; }
        public int Days { get; set; }
        public int Price { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }

    }
}
