using System;
using System.Collections.Generic;

namespace JobPlsApi.Models
{
    public partial class Company
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? LinkToWebsite { get; set; }
    }
}
