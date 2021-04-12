using GraphQL.Types;
using MyHoursApi.Models;


namespace MyHoursApi.GraphQL.Types
{
    public class RelationInputType : InputObjectGraphType
    {
        public RelationInputType()
        {
            Name = "RelationInput";
            Field<NonNullGraphType<StringGraphType>>("dashboard");
            Field<NonNullGraphType<StringGraphType>>("date");
            Field<NonNullGraphType<StringGraphType>>("isActive");
            Field<NonNullGraphType<StringGraphType>>("time");
            Field<NonNullGraphType<StringGraphType>>("user");
            Field<NonNullGraphType<StringGraphType>>("project");
        }
    }
}