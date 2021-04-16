using System.Collections.Generic;

namespace MyHoursApi.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string ProjectName { get; set; }
        public bool IsActive { get; set; }

    }
}