using System;
using System.Collections.Generic;
using System.Linq;

namespace VMatveevLesson5
{
    public class Worker
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public Department Department { get; set; }

        public Worker(int id, Employee employee, Department department)
        {
            this.Id = id;
            this.Employee = employee;
            this.Department = department;
        }

        public Worker()
        {

        }
    }
}
