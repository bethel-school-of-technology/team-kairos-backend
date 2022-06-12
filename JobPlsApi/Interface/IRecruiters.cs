using JobPlsApi.Models;

namespace JobPlsApi.Interface
{
    public interface IRecruiters
    {
        public List<Recruiter> GetRecruiterDetails();
        public Recruiter GetRecruiterDetails(int id);
        public void AddRecruiter(Recruiter recruiter);
        public void UpdateRecruiter(Recruiter recruiter);
        public Recruiter DeleteRecruiter(int id);
        public bool CheckRecruiter(int id);
    }
}