namespace JobPlsApi.Models
{
    public partial class ListJobPosts
    {
        public long? Id { get; set; }
        public List<JobPost>? JobPosts{ get; set; }
    }
}