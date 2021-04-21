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

    class MyHourMutation : ObjectGraphType
    {
        public MyHourMutation(UserRepository userRepository, RelationRepository relationRepository, ProjectRepository projectRepository)
        {
            
            Field<RelationType>("createRelation",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<RelationInputType>> { Name = "input" }),
                resolve: context => relationRepository.Create(context.GetArgument<Relation>("input"))
            );
            
            Field<RelationType>("deleteRelation",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context => relationRepository.Delete(context.GetArgument<long>("id"))
            );

            Field<RelationType>("updateRelation",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" },
                                              new QueryArgument<NonNullGraphType<RelationInputType>> { Name = "input" }),
                resolve: context => relationRepository.Update(context.GetArgument<long>("id"), 
                                                             context.GetArgument<Relation>("input"))
            );
            Field<RelationType>("updateRelationTime",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" },
                                              new QueryArgument<NonNullGraphType<RelationInputType>> { Name = "input" }),
                resolve: context => relationRepository.UpdateTime(context.GetArgument<long>("id"), 
                                                             context.GetArgument<Relation>("input"))
            );

            Field<ProjectType>("createProject",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProjectInputType>> { Name = "input" }),
                resolve: context => projectRepository.Create(context.GetArgument<Project>("input"))
            );

            Field<ProjectType>("deleteProject",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context => projectRepository.Delete(context.GetArgument<long>("id"))
            );

            Field<ProjectType>("updateProject",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" },
                                              new QueryArgument<NonNullGraphType<ProjectInputType>> { Name = "input" }),
                resolve: context => projectRepository.Update(context.GetArgument<long>("id"), 
                                                             context.GetArgument<Project>("input"))
            );

            Field<UserType>("createUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UserInputType>> { Name = "input" }),
                resolve: context => userRepository.Create(context.GetArgument<User>("input"))
            );

            Field<UserType>("deleteUser",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context => userRepository.Delete(context.GetArgument<long>("id"))
                );

            Field<UserType>("updateUser",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" },
                                              new QueryArgument<NonNullGraphType<UserInputType>> { Name = "input" }),
                resolve: context => userRepository.Update(context.GetArgument<long>("id"), 
                                                             context.GetArgument<User>("input"))
            );
            
        }
    }
}