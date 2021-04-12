using System.Collections.Generic;

namespace MyHoursApi.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public long ProjectId { get; set; }
        public List<Project> Projects { get; set; }
    }
}