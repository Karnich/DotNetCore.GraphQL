using DotNetCore.GraphQL.Basic.Models;
using System.Collections.Generic;

namespace DotNetCore.GraphQL.Basic.Services
{
    public class GraphQLService
    {
        private List<Person> _owners = new List<Person>
        {
            new Person() { Age = 21, Id = "number1", Name = "John", Cars = new List<string>{"plate1"} },
            new Person() { Age = 21, Id = "number2", Name = "Bo", Cars = new List<string>{"plate2", "plate3"} }
        };

        private List<Car> _cars = new List<Car>
        {
            new Car() { Model = "Ford Mondeo", OwnerId = "number1", LicensePlate = "plate1" },
            new Car() { Model = "Ferrari F40", OwnerId = "number2", LicensePlate = "plate2" },
            new Car() { Model = "VW Golf", OwnerId = "number2", LicensePlate = "plate3" }
        };

        public Car GetCar(string plate)
        {
            return _cars.Find(x => x.LicensePlate == plate);
        }

        public List<Car> GetCars()
        {
            return _cars;
        }

        public Person GetOwner(string id)
        {
            return _owners.Find(x => x.Id == id);
        }

        public List<Person> GetOwners()
        {
            return _owners;
        }
    }
}
