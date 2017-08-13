using DotNetCore.GraphQL.Basic.Models;
using GraphQL.Types;

namespace DotNetCore.GraphQL.Basic.Types
{
    public class CarType : ObjectGraphType<Car>
    {
        public CarType()
        {
            Name = "Car";
            Description = "A Car has a license plate and an owner";
            Field(h => h.LicensePlate, nullable: false).Description("The license plate of the person");
            Field<PersonType>(
                 "Owner",
                 "The person who owns this car",
                 resolve: context =>
                 {
                     return null;
                 }
             );
        }
    }
}
