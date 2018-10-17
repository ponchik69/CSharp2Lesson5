using System;
using System.Collections.Generic;
using System.Linq;

namespace VMatveevLesson5
{
    public class Employee
    {
        public int UUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;

        }
    }
}
