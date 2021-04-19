using Microsoft.EntityFrameworkCore;
using MyHoursApi.Models;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;

namespace MyHoursApi.Repositories
{
    public class UserRepository
    {
        private readonly DatabaseContext _context;
        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<User> All(){
            return _context.Users.ToList();
        }
        public long auth(string email, string password)
        {
            var res = _context.Users.Where(c => c.Email == email && c.Password == password).FirstOrDefault();
            var i = res.Id;
            return i;
        }

        public IEnumerable<User> Filter(ResolveFieldContext<object> graphqlContext){
            var results = from users in _context.Users select users;
            if (graphqlContext.HasArgument("email")) {
                var name = graphqlContext.GetArgument<string>("email");
                results = results.Where(c => c.Email.Equals(name));
            }
             if (graphqlContext.HasArgument("name")) {
                 var name = graphqlContext.GetArgument<string>("name");
                 results = results.Where(c => c.Name.Equals(name));
             }
            return results;
        }

        public User Find(long id) {
            return _context.Users.Find(id);
        }

        public User Create(User user){
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Delete(long id){
            var user = _context.Users.Find(id);
            if (user == null) {
                return null;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public User Update(long id, User user) {
            user.Id = id;
            var updated = (_context.Users.Update(user)).Entity;
            if (updated == null) {
                return null;
            }
            _context.SaveChanges();
            return user;
        }
    }
}