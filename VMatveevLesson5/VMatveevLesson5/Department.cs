using System;
using System.Collections.Generic;
using System.Linq;

namespace VMatveevLesson5
{
    public class Department
    {
        public int UUID { get; set; }
        public string DepartmentName { get; set; }

        public override string ToString()
        {
            return DepartmentName;
        }
    }
}
