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

        public IEnumerable<Project> GetProjects(long id) {
            List<Relation> relations = new List<Relation>();

            relations = _context.Relations.Where(g => g.userId == id).ToList();

            List<Project> projects = new List<Project>();
            foreach (Relation relation in relations){
                Project p = _context.Projects.Find(relation.projectId);

                projects.Add(p);
            }
            return projects;
        }
        public IEnumerable<User> Users(long id) {
            var results = from users in _context.Users select users;
            results = results.Where(b => b.Id == id);
            return results;
        }
        public long GetRelation(long userid, long projectid){
            var res = _context.Relations.Where(c => c.userId == userid && c.projectId == projectid).FirstOrDefault();
            var i = res.Id;
            return i;
        }

        public double GetTime(long userid, long projectid){
            var res = _context.Relations.Where(c => c.userId == userid && c.projectId == projectid).FirstOrDefault();
            var i = res.Time;
            return i;
        }

        public double TotalProject(long id){
            List<Relation> reports = new List<Relation>();

            reports = _context.Relations.Where(r => r.projectId == id).ToList();

            double hours= 0;
            foreach (Relation relation in reports)
            {
                hours += relation.Time;
            }
            return hours;
        }

        public double TotalUser(long id){
            List<Relation> reports = new List<Relation>();

            reports = _context.Relations.Where(r => r.userId == id).ToList();

            double hours= 0;
            foreach (Relation relation in reports)
            {
                hours += relation.Time;
            }
            return hours;
        }

        public IEnumerable<Relation> Filter(ResolveFieldContext<object> graphqlContext){
            var results = from relations in _context.Relations select relations;
            if (graphqlContext.HasArgument("userid")) {
                var name = graphqlContext.GetArgument<long>("userid");
                results = results.Where(c => c.userId.Equals(name));
            }
            //  if (graphqlContext.HasArgument("name")) {
            //      var name = graphqlContext.GetArgument<string>("name");
            //      results = results.Where(c => c.Name.Contains(name));
            //  }
            return results;
        }

        public IEnumerable<Relation> All(){
            return _context.Relations.ToList();
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
            var relation = _context.Relations.Where(r => r.projectId == id);
            
            if (relation == null) {
                return null;
            }
            _context.Relations.Remove((Relation)relation);
            _context.SaveChanges();
            return (Relation)relation;
        }

        public Relation Update(long id, Relation relation) {
            relation.Id = id;
            var time = relation.Time;
            var updated = (_context.Relations.Update(relation)).Entity;
            if (updated == null) {
                return null;
            }
            _context.SaveChanges();
            return relation;
        }
        public Relation UpdateTime(long id, Relation relation) {
            relation.Id= id;
            var updated = (_context.Relations.Update(relation)).Entity;
            if (updated == null) {
                return null;
            }
            _context.SaveChanges();
            return relation;
        }
    }
}