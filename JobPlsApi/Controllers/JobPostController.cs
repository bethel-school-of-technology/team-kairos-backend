using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JobPlsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostController : ControllerBase
    {
        private readonly JobPostContext _context;

        public JobPostController(JobPostContext context)
        {
            _context = context;
        }

// Get list of cars and filter with newest car year first.
        // GET: api/JobPost
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobPost>>> GetJobPosts(string sortOrder)
        {
             return _context.JobPosts;
        }

        // GET: api/JobPost/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobPost>> GetJobPost(int id)
        {
            var jobPost = await _context.JobPosts.FindAsync(id);

            if (jobPost == null)
            {
                return NotFound();
            }

            return jobPost;
        }

        // PUT: api/JobPost/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobPost(int id, JobPost jobPost)
        {
            if (id != jobPost.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/JobPost
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobPost>> PostJobPost(JobPost jobPost)
        {
            _context.JobPosts.Add(jobPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobPost", new { id = jobPost.Id }, jobPost);
        }

        // DELETE: api/JobPost/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobPost(int id)
        {
            var jobPost = await _context.JobPosts.FindAsync(id);
            if (jobPost == null)
            {
                return NotFound();
            }

            _context.JobPosts.Remove(jobPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobPostExists(int id)
        {
            return _context.JobPosts.Any(e => e.Id == id);
        }
    }
}
