namespace JobPlsApi.Models
{
    public partial class JobDescription
    {
        public long? Id { get; set; }
        public string? Description { get; set; }
        public string? JobLocation { get; set; }
        public long? MinPayRange { get; set; }
        public long? MaxPayRange { get; set; }
    }
}