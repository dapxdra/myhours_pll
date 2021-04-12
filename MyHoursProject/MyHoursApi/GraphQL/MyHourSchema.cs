using GraphQL;
using GraphQL.Types;

namespace MyHoursApi.GraphQL
{
    class MyHourSchema : Schema
    {
        public MyHourSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<MyHourQuery>();
            Mutation = resolver.Resolve<MyHourMutation>();
        }
    }
}