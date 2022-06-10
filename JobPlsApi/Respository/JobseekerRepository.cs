using JobPlsApi.Interface;
using JobPlsApi.Models;
using Microsoft.EntityFrameworkCore;


    public class JobseekerRepository : IJobseeker
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
                return _dbContext.jobseeker.ToList();
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
                JobseekerInfo? jobseeker = _dbContext.Jobseeker.Find(id);
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
                _dbContext.Jobseeker.Add(jobseeker);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateEmployee(JobseekerInfo jobseeker)
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
                JobseekerInfo? jobseeker = _dbContext.jobseeker.Find(id);

                if (jobseeker != null)
                {
                    _dbContext.jobseeker.Remove(jobseeker);
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
            return _dbContext.jobseeker.Any(e => e.EmployeeID == id);
        }
    }

