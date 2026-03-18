using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    public class Employees
    {
        public string Name { get; set; }
        public string Department { get; set; }

        public override string ToString() => $"{Name} - {Department}";
    }
}
