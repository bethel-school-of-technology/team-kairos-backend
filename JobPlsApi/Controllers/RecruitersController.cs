using JobPlsApi.Interface;
using JobPlsApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPlsApi.Controllers
{
    [Route("api/recruiter")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiters _IRecruiter;

        public RecruiterController(IRecruiters IRecruiter)
        {
            _IRecruiter = IRecruiter;
        }

        // GET: api/recruiter>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recruiter>>> Get()
        {
            return await Task.FromResult(_IRecruiter.GetRecruiterDetails());
        }

        // GET api/recruiter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recruiter>> Get(int id)
        {
            var recruiters = await Task.FromResult(_IRecruiter.GetRecruiterDetails(id));
            if (recruiters == null)
            {
                return NotFound();
            }
            return recruiters;
        }

        // POST api/recruiter
        [HttpPost]
        public async Task<ActionResult<Recruiter>> Post(Recruiter recruiter)
        {
            _IRecruiter.AddRecruiter(recruiter);
            return await Task.FromResult(recruiter);
        }

        // PUT api/recruiter/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Recruiter>> Put(int id, Recruiter recruiter)
        {
            if (id != recruiter.UserId)
            {
                return BadRequest();
            }
            try
            {
                _IRecruiter.UpdateRecruiter(recruiter);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecruiterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(recruiter);
        }

        // DELETE api/recruiter/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recruiter>> Delete(int id)
        {
            var recruiter = _IRecruiter.DeleteRecruiter(id);
            return await Task.FromResult(recruiter);
        }

        private bool RecruiterExists(int id)
        {
            return _IRecruiter.CheckRecruiter(id);
        }
    }
}