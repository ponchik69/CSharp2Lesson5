using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;

namespace VMatveevLesson5
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

        public static void ExecuteWorkers(ObservableCollection<Worker> workersList, List<Department> departmentList, List<Employee> employeeList)
        {
            Employee employee;
            Department department;
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

                        department = new Department();
                        employee = new Employee();
                        worker = new Worker();
                        worker.Id = (int)reader.GetValue(0);

                        foreach (Employee tmpEmp in employeeList)
                        {
                            if (tmpEmp.UUID == (int)reader["id_employee"])
                                worker.Employee = tmpEmp;
                        }

                        foreach (Department tmpDep in departmentList)
                        {
                            if (tmpDep.UUID == (int)reader["id_departament"])
                                worker.Department = tmpDep;
                        }

                        workersList.Add(worker);
                    }
                }
            }
        }

        public static int InserntWorkers(int idEmployee, int idDepartament)
        {
            var sql_insert = $@"INSERT INTO Workers (id_employee, id_departament) OUTPUT INSERTED.ID VALUES ('{idEmployee}', '{idDepartament}')";

            using (var connection = new SqlConnection(str.ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand(sql_insert, connection);

                return (int)command.ExecuteScalar();
            }
        }

        public static int UpdateWorkers(int id, int idEmployee, int idDepartament)
        {
            var sql_update = $@"UPDATE Workers SET id_employee = '{idEmployee}', id_departament = '{idDepartament}' WHERE id = '{id}'";

            using (var connection = new SqlConnection(str.ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand(sql_update, connection);

                return (int)command.ExecuteNonQuery();
            }
        }

        public static int RemoveWorkers(int id)
        {
            var sql_update = $@"DELETE FROM Workers WHERE id = '{id}'";

            using (var connection = new SqlConnection(str.ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand(sql_update, connection);

                return (int)command.ExecuteNonQuery();
            }
        }
    }
}
