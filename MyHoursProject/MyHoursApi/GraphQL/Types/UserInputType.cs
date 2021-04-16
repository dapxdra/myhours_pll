using GraphQL.Types;
using MyHoursApi.Models;


namespace MyHoursApi.GraphQL.Types
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "UserInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("lastname");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<StringGraphType>>("password");
            Field<NonNullGraphType<BooleanGraphType>>("isActive");
        }
    }
}