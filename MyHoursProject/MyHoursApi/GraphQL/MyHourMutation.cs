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
        public ProjectRepository projectRepository;
        public RelationRepository relationRepository;
        public UserRepository userRepository;
        public MyHourMutation()
        {

            createRelation();
            deleteRelation();
            updateRelation();

            createProject();
            deleteProject();
            updateProject();

            createUser();
            deleteUser();
            updateUser();
            
        }

        public void createRelation(){
            Field<ProjectType>("createRelation",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<RelationInputType>> { Name = "input" }),
                resolve: context => relationRepository.Create(context.GetArgument<Relation>("input"))
            );
        }

        public void deleteRelation(){
            Field<ProjectType>("deleteRelation",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context => relationRepository.Delete(context.GetArgument<long>("id"))
            );
        }

        public void updateRelation(){
            Field<ProjectType>("updateRelation",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" },
                                              new QueryArgument<NonNullGraphType<RelationInputType>> { Name = "input" }),
                resolve: context => relationRepository.Update(context.GetArgument<long>("id"), 
                                                             context.GetArgument<Relation>("input"))
            );
        }

        public void createProject(){
            Field<ProjectType>("createProject",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProjectInputType>> { Name = "input" }),
                resolve: context => projectRepository.Create(context.GetArgument<Project>("input"))
            );
        }

        public void deleteProject(){
            Field<ProjectType>("deleteProject",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context => projectRepository.Delete(context.GetArgument<long>("id"))
            );
        }

        public void updateProject(){
            Field<ProjectType>("updateProject",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" },
                                              new QueryArgument<NonNullGraphType<ProjectInputType>> { Name = "input" }),
                resolve: context => projectRepository.Update(context.GetArgument<long>("id"), 
                                                             context.GetArgument<Project>("input"))
            );
        }

        public void createUser(){
            Field<UserType>("createUser",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" },
                                              new QueryArgument<NonNullGraphType<UserInputType>> { Name = "input" }),
                resolve: context => userRepository.Update(context.GetArgument<long>("id"), 
                                                             context.GetArgument<User>("input"))
            );
        }
        public void deleteUser(){
            Field<UserType>("deleteUser",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" },
                                              new QueryArgument<NonNullGraphType<UserInputType>> { Name = "input" }),
                resolve: context => userRepository.Update(context.GetArgument<long>("id"), 
                                                             context.GetArgument<User>("input"))
            );
        }
        public void updateUser(){
            Field<UserType>("updateUser",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" },
                                              new QueryArgument<NonNullGraphType<UserInputType>> { Name = "input" }),
                resolve: context => userRepository.Update(context.GetArgument<long>("id"), 
                                                             context.GetArgument<User>("input"))
            );
        }
    }
}