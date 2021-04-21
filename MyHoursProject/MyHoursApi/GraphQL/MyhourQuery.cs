using GraphQL;
using MyHoursApi.Models;
using GraphQL.Types;
using MyHoursApi.GraphQL.Types;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MyHoursApi.Repositories;
using System;

namespace MyHoursApi.GraphQL
{
    
    class MyHourQuery : ObjectGraphType
    {

        public MyHourQuery(UserRepository userRepository, ProjectRepository projectRepository, RelationRepository relationRepository)
        {
            Field<ListGraphType<UserType>>("users",
             arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "email" },
                    new QueryArgument<StringGraphType> { Name = "name" }
                ),
                resolve: context => userRepository.Filter(context));
            Field<ListGraphType<UserType>>("getusers",
                resolve: context => userRepository.All());

            Field<ListGraphType<ProjectType>>("getprojects",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "userid" }
                ),
                resolve: context => relationRepository.GetProjects(context.GetArgument<long>("userid"))
                );
            Field<IntGraphType>("getrelation",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "userid" },
                    new QueryArgument<IdGraphType> { Name = "projectid" }
                ),
                resolve: context => relationRepository.GetRelation(context.GetArgument<long>("userid"),
                context.GetArgument<long>("projectid"))
                );
            Field<IntGraphType>("gettime",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "userid" },
                    new QueryArgument<IdGraphType> { Name = "projectid" }
                ),
                resolve: context => relationRepository.GetTime(context.GetArgument<long>("userid"),
                context.GetArgument<long>("projectid"))
                );

            Field<FloatGraphType>("sumPro",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "projectid" }
                ),
                resolve: context => relationRepository.TotalProject(context.GetArgument<long>("projectid"))
                );
            Field<FloatGraphType>("sumUser",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "userid" }
                ),
                resolve: context => relationRepository.TotalUser(context.GetArgument<long>("userid"))
                );

            Field<ListGraphType<RelationType>>("relation",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "userid" }
                ),
                resolve: context => relationRepository.Filter(context));

            Field<UserType>("user",
             arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context => userRepository.Find(context.GetArgument<long>("id"))
            );
            // Field<ListGraphType<UserType>>("users", resolve: context => userRepository.All());

            Field<IntGraphType>("auth",
             arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "email" },
                    new QueryArgument<StringGraphType> { Name = "password" }
                ),
                resolve: context => userRepository.auth(context.GetArgument<string>("email"),
                                                        context.GetArgument<string>("password")));

            Field<ListGraphType<ProjectType>>("projects",
             arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "pname" }
                ),
                resolve: context => projectRepository.Filter(context));
            
        }
    }
}