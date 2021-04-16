using GraphQL.Types;
using MyHoursApi.Models;
using MyHoursApi.Repositories;


namespace MyHoursApi.GraphQL.Types
{
    public class ProjectType : ObjectGraphType<Project>
    {
        public ProjectType(ProjectRepository repository)
        {
            Name = "Project";
            Field(x => x.Id);
            Field(x => x.ProjectName);
            Field(x => x.IsActive);
            
        }
    }
}