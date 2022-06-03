using System;
using System.Collections.Generic;

namespace JobPlsApi.Models
{
    public partial class JobPost
    {
        public long Id { get; set; }
        public string JobCompany { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public string JobDescription { get; set; } = null!;
        public string JobLocation { get; set; } = null!;
        public long MinPayRange { get; set; }
        public long? MaxPayRange { get; set; }
    }
}
