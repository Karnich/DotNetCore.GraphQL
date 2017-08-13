using GraphQL.Types;
using System;

namespace DotNetCore.GraphQL.Basic.GraphQL
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(Func<Type, GraphType> resolveType)
            : base(resolveType)
        {
            Query = (RootQuery)resolveType(typeof(RootQuery));
        }
    }
}
