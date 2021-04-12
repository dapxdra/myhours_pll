using Microsoft.EntityFrameworkCore;
using MyHoursApi.Models;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;

namespace MyHoursApi.Repositories
{
    public class RelationRepository
    {
        private readonly DatabaseContext _context;
        public RelationRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> Projects(long id) {
            var results = from projects in _context.Projects select projects;
            results = results.Where(b => b.Id == id);
            return results;
        }
        public IEnumerable<User> Users(long id) {
            var results = from users in _context.Users select users;
            results = results.Where(b => b.Id == id);
            return results;
        }

        public IEnumerable<Relation> Filter(ResolveFieldContext<object> graphqlContext){
            var results = from relations in _context.Relations select relations;
            if (graphqlContext.HasArgument("dashboard")) {
                var name = graphqlContext.GetArgument<string>("dashboard");
                results = results.Where(c => c.Dashboard.Equals(name));
            }
            //  if (graphqlContext.HasArgument("name")) {
            //      var name = graphqlContext.GetArgument<string>("name");
            //      results = results.Where(c => c.Name.Contains(name));
            //  }
            return results;
        }

        public Relation Find(long id) {
            return _context.Relations.Find(id);
        }

        public Relation Create(Relation relation){
            _context.Relations.Add(relation);
            _context.SaveChanges();
            return relation;
        }

        public Relation Delete(long id){
            var relation = _context.Relations.Find(id);
            if (relation == null) {
                return null;
            }
            _context.Relations.Remove(relation);
            _context.SaveChanges();
            return relation;
        }

        public Relation Update(long id, Relation relation) {
            relation.Id = id;
            var updated = (_context.Relations.Update(relation)).Entity;
            if (updated == null) {
                return null;
            }
            _context.SaveChanges();
            return relation;
        }
    }
}