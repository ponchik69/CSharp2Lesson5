using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMatveevLesson5
{
   public class Organizattion
    {
        public EList eList = new EList();
        public DList dList = new DList();

        #region eList

        public Employee GetEmployeeListItem(int index)
        {
            return eList.employeeList[index];
        }

        public int GetEmployeeListCount()
        {
            return eList.employeeList.Count;
        }

        public void AddEmployeeListItem(Employee item)
        {
            eList.employeeList.Add(item);
        }

        #endregion

        #region dList

        public Department GetDepartmentListItem(int index)
        {
            return dList.departmentList[index];
        }

        public int GetDepartmentListCount()
        {
            return dList.departmentList.Count;
        }

        public void AddDepartmentListItem(Department item)
        {
            dList.departmentList.Add(item);
        }

        #endregion
    }
}
