using DotNetCore.GraphQL.Basic.Models;
using GraphQL.Types;

namespace DotNetCore.GraphQL.Basic.Types
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Name = "Owner";
            Description = "A Person has a name, an age and can have multiple cars";
            Field(h => h.Name, nullable: false).Description("Name of the person");
            Field(h => h.Age, nullable: false).Description("Age of the person");
            //Field<ListGraphType<CarType>>(
            //     "Cars",
            //     "The cars this person owns",
            //     resolve: context =>
            //     {
            //         return context.Source.Cars;
            //     }
            // );
        }
    }
}
