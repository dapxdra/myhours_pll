using GraphQL;
using MyHoursApi.Models;
using GraphQL.Types;
using MyHoursApi.GraphQL.Types;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MyHoursApi.Repositories;

namespace MyHoursApi.GraphQL
{
    
    class MyHourQuery : ObjectGraphType
    {

        public MyHourQuery(UserRepository userRepository, ProjectRepository projectRepository)
        {
            Field<ListGraphType<UserType>>("users",
             arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "email" },
                    new QueryArgument<StringGraphType> { Name = "name" }
                ),
                resolve: context => userRepository.Filter(context));

            Field<UserType>("user",
             arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context => userRepository.Find(context.GetArgument<long>("id"))
            );
            // Field<ListGraphType<UserType>>("users", resolve: context => userRepository.All());
            
        }
    }
}