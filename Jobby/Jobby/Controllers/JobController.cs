using Core.Dtos;
using Core.Entities;
using Core.Errors;
using Core.Interfaces;
using Jobby.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jobby.Controllers
{
    [Route("api/job")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public JobController(IJobService jobService, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _jobService = jobService;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("add-job")]
        public ActionResult<JobToReturnDto> CreateJob(JobToCreateDto dto)
        {
            var email = _httpContextAccessor.HttpContext?.User.RetrieveEmailFromPrincipal();
            var job =_jobService.CreateJobAsync(email, dto.Title, dto.Description, dto.ExpectedDays, dto.Budget, dto.CategoryId,dto.Skills);
            if (job == null) return BadRequest(new ApiResponse(400, "Problem Creating Your Job"));
            return Ok(job);
        }
        [HttpGet("get-job-categories")]
        public ActionResult<Category> GetCategories()
        {
             return Ok(_unitOfWork.Repository<Category>().ListAllAsync());
        }
        [HttpGet("get-job-by-id")]
        public ActionResult<JobToReturnDto> GetJobById(int id)
        {
            var job = _jobService.GetJobByIdAsync(id);
            return Ok(job);
        }
        [HttpGet("get-job-for-user")]
        public ActionResult<JobToReturnDto> GetJobByIdForUser(int jobId)
        {
            var email = _httpContextAccessor.HttpContext?.User.RetrieveEmailFromPrincipal();
            var job = _jobService.GetJobByIdForUser(jobId, email);
            return Ok(job);

        }
        [HttpGet("get-jobs-for-user")]
        public ActionResult <IReadOnlyList<JobToReturnDto>> GetUserJobs()
        {
            var email = _httpContextAccessor.HttpContext?.User.RetrieveEmailFromPrincipal();
            var jobs = _jobService.GetJobsForUserAsync(email);
            return Ok(jobs);

        }
    }
}
