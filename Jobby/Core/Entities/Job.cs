namespace Core.Entities
{
    public class Job : BaseEntity
    {
        public Job()
        {
            
        }

        public Job(string email, string title, string description, int expectedDays, int budget, int categoryId, List<JobSkills> skills)
        {
            Email = email;
            Title = title;
            Description = description;
            ExpectedDays = expectedDays;
            Budget = budget;
            CategoryId = categoryId;
            Skills = skills;
            Created = DateTime.UtcNow;
        }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ExpectedDays { get; set; }
        public int Budget { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; } 
        public DateTime Created { get; set; }
        public List<JobSkills> Skills { get; set; } = new();
        public List<Offer> Offers { get; set; } = new();
        public string Email { get; set; }

    }
}
