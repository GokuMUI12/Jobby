﻿using Core.Entities;

namespace Core.Specification
{
    public class JobWithSkillsSpecification : BaseSpecification<Job>
    {
        public JobWithSkillsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Skills);
            AddInclude(x => x.Category);
            AddInclude(x => x.Offers);

        }
        public JobWithSkillsSpecification(string email) : base(x => x.Email == email)
        {
            AddInclude(x => x.Skills);
            AddInclude(x => x.Category);
            AddInclude(x => x.Offers);

        }
        public JobWithSkillsSpecification(int jobId, string email) : base(x => x.Id == jobId 
            && x.Email == email)
        {
            AddInclude(x => x.Skills);
            AddInclude(x => x.Offers);
            AddInclude(x => x.Category);
        }

        public JobWithSkillsSpecification()
        {
            AddInclude(x => x.Skills);
            AddInclude(x => x.Offers);
            AddInclude(x => x.Category);

        }

    }
}
