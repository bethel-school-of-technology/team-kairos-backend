using JobPlsApi.Data;
using JobPlsApi.Interface;
using JobPlsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPlsApi.Repository
{
    public class RecruiterRepository : IRecruiters
    {
        readonly AppDbContext _dbContext = new();

        public RecruiterRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Recruiter> GetRecruiterDetails()
        {
            try
            {
                return _dbContext.Recruiters.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Recruiter GetRecruiterDetails(int id)
        {
            try
            {
                Recruiter? recruiter = _dbContext.Recruiters.Find(id);
                if (recruiter != null)
                {
                    return recruiter;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddRecruiter(Recruiter recruiter)
        {
            try
            {
                _dbContext.Recruiters.Add(recruiter);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateRecruiter(Recruiter recruiter)
        {
            try
            {
                _dbContext.Entry(recruiter).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Recruiter DeleteRecruiter(int id)
        {
            try
            {
                Recruiter? recruiter = _dbContext.Recruiters.Find(id);

                if (recruiter != null)
                {
                    _dbContext.Recruiters.Remove(recruiter);
                    _dbContext.SaveChanges();
                    return recruiter;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckRecruiter(int id)
        {
            return _dbContext.Recruiters.Any(e => e.UserId == id);
        }
    }
}