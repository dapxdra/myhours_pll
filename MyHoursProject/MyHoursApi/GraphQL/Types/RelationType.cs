using GraphQL.Types;
using MyHoursApi.Models;
using MyHoursApi.Repositories;


namespace MyHoursApi.GraphQL.Types
{
    public class RelationType : ObjectGraphType<Relation>
    {
        public RelationType(RelationRepository repository)
        {
            Name = "Relation";
            Field(x => x.Id);
            Field(x => x.Dashboard);
            Field(x => x.Date);
            Field(x => x.Time);
            Field(x => x.IsActive);
            Field(x => x.userId);
            Field(x => x.projectId);
        }
    }
}