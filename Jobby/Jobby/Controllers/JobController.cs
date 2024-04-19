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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public JobController(IJobService jobService, IHttpContextAccessor httpContextAccessor)
        {
            _jobService = jobService;
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
        public async Task<ActionResult<Category>> GetCategories()
        {
             return Ok(await _jobService.GetCategories());
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

        [HttpGet("jobs")]
        public async Task <IActionResult> GetJobs()
        {
            return Ok(await _jobService.GetAllJobs());
        } 


    }
}
