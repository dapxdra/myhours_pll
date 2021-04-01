namespace MyHours.Entities{
    public class Project_User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Project Project {get; set;}
        public User User { get; set; }
    }
}