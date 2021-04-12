using GraphQL;
using MyHoursApi.Models;
using GraphQL.Types;
using MyHoursApi.GraphQL.Types;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MyHoursApi.GraphQL
{
    
    class MyHourQuery : ObjectGraphType
    {
        private readonly DatabaseContext _context;

        public MyHourQuery(DatabaseContext context)
        {
            _context = context;
            Field<ListGraphType<UserType>>("users",
             arguments: new QueryArguments{new QueryArgument<StringGraphType>{Name = "Email"}},
             resolve: context => {
                 var results = from users in _context.Users select users;
                 if (context.HasArgument("Email"))
                 {
                     var email = context.GetArgument<StringGraphType>("email");
                     results = results.Where(c => c.Email.Equals(email));
                 }
                 return results;
            });
            Field<UserType>("user",
             arguments: new QueryArguments{new QueryArgument<IdGraphType>{Name = "id"}},
             resolve: context => {
                return _context.Users.Find(context.GetArgument<long>("id"));
            });
            Field<ListGraphType<ProjectType>>("projects", resolve: context => {
                return _context.Projects.ToListAsync();
            });
        }
    }
}