using System.Text.Json.Serialization;

namespace MyHours.Models{
    class User{
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}