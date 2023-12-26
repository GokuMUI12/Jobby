namespace Core.Entities
{
    public class JobSkills
    {
        public JobSkills()
        {
            
        }
        public JobSkills(string skill)
        {
            SkillName = skill;
        }
        public int Id { get; set; }
        public string SkillName { get; set; }
    }
}
