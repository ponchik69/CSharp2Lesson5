using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMatveevLesson5
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UUID { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;

        }
    }

    public class EList
    {
        Employee employee;
        public List<Employee> employeeList = new List<Employee>();

        public EList()
        {
            for (int i = 0; i < 10; i++)
            {
                employee = new Employee();
                employee.FirstName = MegaGenerator.GetEmployeeName();
                employee.LastName = MegaGenerator.GetEmployeeLastname();
                employee.UUID = i;
                employeeList.Add(employee);
            }
        }

    }
}
