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
            Field<DateTimeGraphType>("date");
            Field<BooleanGraphType>("isActive");
            Field<NonNullGraphType<FloatGraphType>>("time");
            Field<NonNullGraphType<IdGraphType>>("userId");
            Field<NonNullGraphType<IdGraphType>>("projectId");
        }
    }
}