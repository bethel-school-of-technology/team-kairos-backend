using System;
using System.Collections.Generic;

namespace JobPlsApi.Models
{
    public partial class JobPost
    {
        public long Id { get; set; }
        public string? JobCompany { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? JobLocation { get; set; }
        public long MinPayRange { get; set; }
        public long? MaxPayRange { get; set; }
    }
}
