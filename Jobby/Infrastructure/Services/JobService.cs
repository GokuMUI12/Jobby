using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;

namespace Infrastructure.Services
{
    public class JobService :  IJobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public JobService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<JobToReturnDto> CreateJobAsync(string email, string title, string description, int days, int budget, int categoryId, List<string> names)
        {
            var jobSkills = new List<JobSkills>();
            foreach (var name in names)
            {
                var skill = new JobSkills(name);
                jobSkills.Add(skill);
            }
            var job = new Job(email, title,description,days,budget,categoryId,jobSkills);
            _unitOfWork.Repository<Job>().Add(job);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return null;
            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(categoryId);
            return _mapper.Map<JobToReturnDto>(job);
        }

        public async Task<IReadOnlyList<Category>> GetCategories()
        {
             return await _unitOfWork.Repository<Category>().ListAllAsync();
        }

        public async Task<JobToReturnDto> GetJobByIdAsync(int jobId)
        {
            var spec = new JobWithSkillsSpecification(jobId);
            var job = await _unitOfWork.Repository<Job>().GetEntityWithSpec(spec);
            return _mapper.Map<JobToReturnDto>(job);
        }

        public async Task<JobToReturnDto> GetJobByIdForUser(int id, string email)
        {
            var spec = new JobWithSkillsSpecification(id, email);
            var job = await _unitOfWork.Repository<Job>().GetEntityWithSpec(spec);
            return _mapper.Map<JobToReturnDto>(job);
        }

        public async Task<IReadOnlyList<JobToReturnDto>> GetJobsForUserAsync(string email)
        {
            var spec = new JobWithSkillsSpecification(email);
            var jobs = await _unitOfWork.Repository<Job>().ListAsync(spec);
            return _mapper.Map<IReadOnlyList<JobToReturnDto>>(jobs);
        }

        public async Task<IReadOnlyList<JobToReturnDto>> GetAllJobs()
        {
            var spec = new JobWithSkillsSpecification();
            var jobs = await _unitOfWork.Repository<Job>().ListAsync(spec);
            return _mapper.Map<IReadOnlyList<JobToReturnDto>>(jobs);
        }
    }
}
