using GraphQL.Types;
using MyHoursApi.Models;


namespace MyHoursApi.GraphQL.Types
{
    public class ProjectInputType : InputObjectGraphType
    {
        public ProjectInputType()
        {
            Name = "ProjectInput";
            Field<NonNullGraphType<StringGraphType>>("pname");
            Field<NonNullGraphType<StringGraphType>>("description");
            Field<BooleanGraphType>("isActive");
        }
    }
}