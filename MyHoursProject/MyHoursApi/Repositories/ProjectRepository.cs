using Microsoft.EntityFrameworkCore;
using MyHoursApi.Models;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;

namespace MyHoursApi.Repositories
{
    public class ProjectRepository
    {
        private readonly DatabaseContext _context;
        public ProjectRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> All(){
            return _context.Projects.ToList();
        }

        public IEnumerable<Project> Filter(ResolveFieldContext<object> graphqlContext){
            var results = from projects in _context.Projects select projects;
            if (graphqlContext.HasArgument("pname")) {
                var name = graphqlContext.GetArgument<string>("pname");
                results = results.Where(c => c.Pname.Equals(name));
            }
            return results;
        }

        public Project Find(long id) {
            return _context.Projects.Find(id);
        }

        public Project Create(Project project){
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;
        }

        public Project Delete(long id){
            var project = _context.Projects.Find(id);
            if (project == null) {
                return null;
            }
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return project;
        }

        public Project Update(long id, Project project) {
            project.Id = id;
            var updated = (_context.Projects.Update(project)).Entity;
            if (updated == null) {
                return null;
            }
            _context.SaveChanges();
            return project;
        }


    }
}