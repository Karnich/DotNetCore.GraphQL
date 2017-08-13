using DotNetCore.GraphQL.Basic.Services;
using DotNetCore.GraphQL.Basic.Types;
using GraphQL.Types;

namespace DotNetCore.GraphQL.Basic.GraphQL
{
    public class RootQuery : ObjectGraphType<object>
    {
        public RootQuery(GraphQLService service)
        {
            Name = "Query";
            Description = "Queries to make READ operations";

            Field<PersonType>(
                "Owner",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "Id of the car owner" }
                ),
                resolve: context => 
                {
                    var id = context.GetArgument<string>("id");

                    if(id != null)
                    {
                        return service.GetOwner(id);
                    }

                    return service.GetOwners();                    
                }
            );
        }
    }
}
