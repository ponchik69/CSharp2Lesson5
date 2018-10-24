using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFApp
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string connectMessage();

        [OperationContract]
        List<Employee> getEmployees();

        [OperationContract]
        int getEmployeesCount();

        [OperationContract]
        Employee getEmployee(int index);

        [OperationContract]
        List<Department> getDepartaments();

        [OperationContract]
        int getDepartamentsCount();

        [OperationContract]
        Department getDepartament(int index);

        [OperationContract]
        List<Worker> getWorkers();
    }
}
