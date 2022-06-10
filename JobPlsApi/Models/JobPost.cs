using System;
using System.Collections.Generic;

namespace JobPlsApi.Models
{
    public partial class JobPost
    {
        public long? Id { get; set; }
        public Company? Company { get; set; }
        public string? JobTitle { get; set; }
        public JobDescription? JobDescription { get; set; }
        public JobApplicationPortal? JobApplicationPortal { get; set; }
    }
}
