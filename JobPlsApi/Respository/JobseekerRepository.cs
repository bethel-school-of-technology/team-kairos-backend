using JobPlsApi.Interface;
using JobPlsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPlsApi.Repository {

    public class JobseekerRepository : IJobseekers
    {
        readonly DatabaseContext _dbContext = new();

        public JobseekerRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<JobseekerInfo> GetJobseekerDetails()
        {
            try
            {
                return _dbContext.JobseekerInfo.ToList();
            }
            catch
            {
                throw;
            }
        }

        public JobseekerInfo GetJobseekerDetails(int id)
        {
            try
            {
                JobseekerInfo? jobseeker = _dbContext.JobseekerInfo.Find(id);
                if (jobseeker != null)
                {
                    return jobseeker;
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

        public void AddJobseeker(JobseekerInfo jobseeker)
        {
            try
            {
                _dbContext.JobseekerInfo.Add(jobseeker);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateJobseeker(JobseekerInfo jobseeker)
        {
            try
            {
                _dbContext.Entry(jobseeker).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public JobseekerInfo DeleteJobseeker(int id)
        {
            try
            {
                JobseekerInfo? jobseeker = _dbContext.JobseekerInfo.Find(id);

                if (jobseeker != null)
                {
                    _dbContext.JobseekerInfo.Remove(jobseeker);
                    _dbContext.SaveChanges();
                    return jobseeker;
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

        public bool CheckJobseeker(int id)
        {
            return _dbContext.JobseekerInfo.Any(e => e.UserId == id);
        }
    }

}