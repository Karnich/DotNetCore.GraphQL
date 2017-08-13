using System.Collections.Generic;

namespace DotNetCore.GraphQL.Basic.Models
{
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Cars { get; set; }
    }
}
