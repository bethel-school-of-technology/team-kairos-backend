using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Models;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JobPostController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/JobPost
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobPost>>> GetJobPosts()
        {
          if (_context.JobPosts == null)
          {
              return NotFound();
          }
            return await _context.JobPosts.ToListAsync();
        }

        // GET: api/JobPost/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobPost>> GetJobPost(long id)
        {
          if (_context.JobPosts == null)
          {
              return NotFound();
          }
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
        public async Task<IActionResult> PutJobPost(long id, JobPost jobPost)
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
          if (_context.JobPosts == null)
          {
              return Problem("Entity set 'AppDbContext.JobPosts'  is null.");
          }
            _context.JobPosts.Add(jobPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobPost", new { id = jobPost.Id }, jobPost);
        }

        
        // DELETE: api/JobPost/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobPost(long id)
        {
            if (_context.JobPosts == null)
            {
                return NotFound();
            }
            var jobPost = await _context.JobPosts.FindAsync(id);
            if (jobPost == null)
            {
                return NotFound();
            }

            _context.JobPosts.Remove(jobPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobPostExists(long id)
        {
            return (_context.JobPosts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
