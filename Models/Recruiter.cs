using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Recruiter
    {
        public long Id { get; set; }
        public string Organization { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string jobTitle { get; set; }
        public string email { get; set; }

    }
}
