using GraphQL.Types;
using MyHoursApi.Models;


namespace MyHoursApi.GraphQL.Types
{
    public class ProjectInputType : InputObjectGraphType
    {
        public ProjectInputType()
        {
            Name = "ProjectInput";
            Field<NonNullGraphType<StringGraphType>>("projectName");
            Field<NonNullGraphType<StringGraphType>>("isActive");
        }
    }
}