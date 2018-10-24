using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFApp
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}
        List<Employee> employeeList = new List<Employee>();
        List<Department> departamentList = new List<Department>();
        List<Worker> workerList = new List<Worker>();

        public Service1()
        {
            SQLer.ExecuteEmployee(employeeList);
            SQLer.ExecuteDepartament(departamentList);
            SQLer.ExecuteWorkers(workerList);
        }

        public string connectMessage() => "Connection successful";

        public int getEmployeesCount()
        {
            return employeeList.Count();
        }

        public Employee getEmployee(int index)
        {
            return employeeList[index];
        }

        public List<Employee> getEmployees()
        {
            return employeeList;
        }

        public List<Department> getDepartaments()
        {
            return departamentList;
        }

        public int getDepartamentsCount()
        {
            return departamentList.Count();
        }

        public Department getDepartament(int index)
        {
            return departamentList[index];
        }

        public List<Worker> getWorkers()
        {
            return workerList;
        }

    }
}
