using System.Collections.Generic;

namespace MyHoursApi.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string Pname { get; set; }

        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}