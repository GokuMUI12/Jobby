using Core.Dtos;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IJobService { 
        Task<JobToReturnDto> CreateJobAsync(string email, string title, string description, int days,
            int budget, int categoryId, List<string> names);
        Task<JobToReturnDto> GetJobByIdAsync(int jobId);
        Task<JobToReturnDto> GetJobByIdForUser(int id,string email);
        Task<IReadOnlyList<JobToReturnDto>> GetJobsForUserAsync(string email);
        Task<IReadOnlyList<Category>> GetCategories();
        Task<IReadOnlyList<JobToReturnDto>> GetAllJobs();
        
    }
}
