namespace Core.Dtos
{
    public class JobToReturnDto
    {
        public string Email { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ExpectedDays { get; set; }
        public int Budget { get; set; }
        public string CategoryName { get; set; }
        public DateTime Created { get; set; }
        public List<string> Skills { get; set; }
        public int Count { get; set; }
    }
}
