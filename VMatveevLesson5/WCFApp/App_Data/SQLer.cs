using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;

namespace WCFApp
{
    static class SQLer
    {
        static ConnectionStringSettings str = ConfigurationManager.ConnectionStrings["DefaultConnection"];

        public static void ExecuteEmployee(List<Employee> employeeList)
        {
            Employee employee;
            var sql_select = "SELECT * FROM Employee";

            using (var connection = new SqlConnection(str.ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand(sql_select, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return;

                    while (reader.Read())
                    {
                        employee = new Employee();
                        employee.UUID = (int)reader.GetValue(0);
                        employee.FirstName = (string)reader["firstName"];
                        employee.LastName = (string)reader["lastName"];
                        employee.Email = (string)reader["email"];
                        employee.Phone = (string)reader["phone"];
                        employeeList.Add(employee);
                        //                        var id = (int)reader.GetValue(0);
                        //                        var firstName = (string)reader["firstName"];
                        //                        var lastName = (string)reader["lastName"];
                        //                        var email = (string)reader["email"];
                        //                        var phone = (string)reader["phone"];
                    }
                }
            }
        }

        public static void ExecuteDepartament(List<Department> departmentList)
        {
            Department department;
            var sql_select = "SELECT * FROM Departament";

            using (var connection = new SqlConnection(str.ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand(sql_select, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return;

                    while (reader.Read())
                    {
                        department = new Department();
                        department.UUID = (int)reader.GetValue(0);
                        department.DepartmentName = (string)reader["name"];
                        departmentList.Add(department);
                    }
                }
            }
        }

        public static void ExecuteWorkers(List<Worker> workersList)
        {
            Worker worker;
            var sql_select = "SELECT * FROM Workers";

            using (var connection = new SqlConnection(str.ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand(sql_select, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return;

                    while (reader.Read())
                    {
                        worker = new Worker();
                        worker.Id = (int)reader.GetValue(0);
                        worker.EmployeeId = (int)reader.GetValue(1);
                        worker.DepartamentId = (int)reader.GetValue(2);
                        workersList.Add(worker);
                    }
                }
            }
        }
    }
}
