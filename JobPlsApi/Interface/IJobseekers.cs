using JobPlsApi.Models;

namespace JobPlsApi.Interface {
public interface IJobseekers
    {
        public List<JobseekerInfo> GetJobseekerDetails();
        public JobseekerInfo GetJobseekerDetails(int id);
        public void AddJobseeker(JobseekerInfo jobseeker);
        public void UpdateJobseeker(JobseekerInfo jobseeker);
        public JobseekerInfo DeleteJobseeker(int id);
        public bool CheckJobseeker(int id);
    }
}