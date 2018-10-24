using System;
using System.Collections.Generic;
using System.Linq;

namespace VMatveevLesson5
{
    public class Department
    {
        public int UUID { get; set; }
        public string DepartmentName { get; set; }

        public Department(int uuid, string departamentName)
        {
            this.UUID = uuid;
            this.DepartmentName = departamentName;
        }

        public Department()
        {

        }

        public override string ToString()
        {
            return DepartmentName;
        }
    }
}
