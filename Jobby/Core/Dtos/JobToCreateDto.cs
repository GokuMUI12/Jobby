namespace Core.Dtos
{
    public class JobToCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ExpectedDays { get; set; }
        public int Budget { get; set; }
        public int CategoryId { get; set; }
        public List<string> Skills { get; set; }
    }
}
