using GraphQL.Types;
using MyHoursApi.Models;
using MyHoursApi.Repositories;


namespace MyHoursApi.GraphQL.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType(UserRepository repository)
        {
            Name = "User";
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Lastname);
            Field(x => x.Email);
            Field(x => x.Password);
            Field(x => x.IsActive);
        }
    }
}