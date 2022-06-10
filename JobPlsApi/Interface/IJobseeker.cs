using JobPlsApi.Models;

public interface IEmployees
    {
        public List<JobseekerInfo> GetEmployeeDetails();
        public JobseekerInfo GetEmployeeDetails(int id);
        public void AddEmployee(JobseekerInfo employee);
        public void UpdateEmployee(JobseekerInfo employee);
        public JobseekerInfo DeleteEmployee(int id);
        public bool CheckEmployee(int id);
    }