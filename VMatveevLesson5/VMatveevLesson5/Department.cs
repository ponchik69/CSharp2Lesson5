using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMatveevLesson5
{
    public class Department
    {
        public string DepartmentName { get; set; }
        public int UUID { get; set; }

        public override string ToString()
        {
            return DepartmentName;
        }
    }


    public class DList
    {
        Department department;
        public List<Department> departmentList = new List<Department>();

        public DList()
        {
            for (int i = 0; i < 5; i++)
            {
                department = new Department();
                department.DepartmentName = MegaGenerator.GetDepartamentName();
                department.UUID = i;
                departmentList.Add(department);
            }
        }

    }
}
