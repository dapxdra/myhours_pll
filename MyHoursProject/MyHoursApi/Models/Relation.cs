using System;
namespace MyHoursApi.Models
{
    public class Relation
    {
        public long Id { get; set; }
        public string Dashboard { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }
        public double Time { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
    }
}