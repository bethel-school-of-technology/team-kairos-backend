using JobPlsApi.Interface;
using JobPlsApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPlsApi.Controllers {
    [Route("api/jobseeker")]
    [ApiController]
    public class JobseekerController : ControllerBase
    {
        private readonly IJobseekers _IJobseeker;

        public JobseekerController(IJobseekers IJobseeker)
        {
            _IJobseeker = IJobseeker;
        }

        // GET: api/JobseekerInfo>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobseekerInfo>>> Get()
        {
            return await Task.FromResult(_IJobseeker.GetJobseekerDetails());
        }

        // GET api/JobseekerInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobseekerInfo>> Get(int id)
        {
            var Jobseekers = await Task.FromResult(_IJobseeker.GetJobseekerDetails(id));
            if (Jobseekers == null)
            {
                return NotFound();
            }
            return Jobseekers;
        }

        // POST api/JobseekerInfo
        [HttpPost]
        public async Task<ActionResult<JobseekerInfo>> Post(JobseekerInfo Jobseeker)
        {
            _IJobseeker.AddJobseeker(Jobseeker);
            return await Task.FromResult(Jobseeker);
        }

        // PUT api/JobseekerInfo/5
        [HttpPut("{id}")]
        public async Task<ActionResult<JobseekerInfo>> Put(int id, JobseekerInfo Jobseeker)
        {
            if (id != Jobseeker.UserId)
            {
                return BadRequest();
            }
            try
            {
                _IJobseeker.UpdateJobseeker(Jobseeker);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobseekerInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(Jobseeker);
        }

        // DELETE api/JobseekerInfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobseekerInfo>> Delete(int id)
        {
            var Jobseeker = _IJobseeker.DeleteJobseeker(id);
            return await Task.FromResult(Jobseeker);
        }

        private bool JobseekerInfoExists(int id)
        {
            return _IJobseeker.CheckJobseeker(id);
        }
    }
}