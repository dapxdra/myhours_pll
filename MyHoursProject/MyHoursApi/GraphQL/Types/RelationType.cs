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
            Field(x => x.IsActive);
            Field(x => x.Time);
            Field<ProjectType>(
                "project",
                resolve: context => {
                    return repository.Projects(context.Source.Project.Id);
                }
            );
            Field<UserType>(
                "user",
                resolve: context => {
                    return repository.Users(context.Source.User.Id);
                }
            );
        }
    }
}