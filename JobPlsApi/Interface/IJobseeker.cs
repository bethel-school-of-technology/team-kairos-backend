using JobPlsApi.Models;

public interface IJobseeker
    {
        public List<JobseekerInfo> GetJobseekerDetails();
        public JobseekerInfo GetJobseekerDetails(int id);
        public void AddJobseeker(JobseekerInfo employee);
        public void UpdateJobseeker(JobseekerInfo employee);
        public JobseekerInfo DeleteJobseeker(int id);
        public bool CheckJobseeker(int id);
    }