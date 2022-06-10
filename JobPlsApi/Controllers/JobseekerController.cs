using JobPlsApi.Interface;
using JobPlsApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


    [Route("api/jobseeker")]
    [ApiController]
    public class JobseekerController : ControllerBase
    {
        private readonly IJobseeker _IJobseeker;

        public JobseekerInfoController(IJobseeker IJobseeker)
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
            var JobseekerInfos = await Task.FromResult(_IJobseeker.GetJobseekerInfoDetails(id));
            if (JobseekerInfos == null)
            {
                return NotFound();
            }
            return JobseekerInfos;
        }

        // POST api/JobseekerInfo
        [HttpPost]
        public async Task<ActionResult<JobseekerInfo>> Post(JobseekerInfo JobseekerInfo)
        {
            _IJobseeker.AddJobseekerInfo(JobseekerInfo);
            return await Task.FromResult(JobseekerInfo);
        }

        // PUT api/JobseekerInfo/5
        [HttpPut("{id}")]
        public async Task<ActionResult<JobseekerInfo>> Put(int id, JobseekerInfo JobseekerInfo)
        {
            if (id != JobseekerInfo.JobseekerInfoID)
            {
                return BadRequest();
            }
            try
            {
                _IJobseeker.UpdateJobseekerInfo(JobseekerInfo);
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
            return await Task.FromResult(JobseekerInfo);
        }

        // DELETE api/JobseekerInfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobseekerInfo>> Delete(int id)
        {
            var JobseekerInfo = _IJobseeker.DeleteJobseekerInfo(id);
            return await Task.FromResult(JobseekerInfo);
        }

        private bool JobseekerInfoExists(int id)
        {
            return _IJobseeker.CheckJobseekerInfo(id);
        }
    }
