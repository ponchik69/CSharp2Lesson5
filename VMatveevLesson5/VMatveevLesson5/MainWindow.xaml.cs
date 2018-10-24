using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace VMatveevLesson5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Worker> workersList { get; set; }

        List<Employee> employeeList = new List<Employee>();
        List<Department> departmentList = new List<Department>();

        public MainWindow()
        {
            InitializeComponent();

            workersList = new ObservableCollection<Worker>();

            //           SQLer.ExecuteEmployee(employeeList);
            //           SQLer.ExecuteDepartament(departmentList);
            //           SQLer.ExecuteWorkers(workersList, departmentList, employeeList);

            //for (int i = 0; i < organizattion.GetEmployeeListCount(); i++)
            //{

            //    employee = organizattion.GetEmployeeListItem(i);
            //    department = organizattion.GetDepartmentListItem(rnd.Next(0, organizattion.GetDepartmentListCount()));
            //    worker = new Worker();
            //    worker.Employee = employee;
            //    worker.Department = department;
            //    workersList.Add(worker);
            //}

            DataContext = this;
        }

        private void GetFromBase_Click(object sender, RoutedEventArgs e)
        {
            if(employeeList.Count > 0)
                employeeList.Clear();

            if (departmentList.Count > 0)
                departmentList.Clear();

            if (workersList.Count > 0)
                workersList.Clear();

            SQLer.ExecuteEmployee(employeeList);
            SQLer.ExecuteDepartament(departmentList);
            SQLer.ExecuteWorkers(workersList, departmentList, employeeList);
        }

        private void GetFromWCF_Click(object sender, RoutedEventArgs e)
        {
            Employee employee;
            Department department;
            Worker worker;

            ServiceReference.Service1Client service = new ServiceReference.Service1Client();

            try
            {
                MessageBox.Show(service.connectMessage(), "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                if (employeeList.Count > 0)
                    employeeList.Clear();

                if (departmentList.Count > 0)
                    departmentList.Clear();

                if (workersList.Count > 0)
                    workersList.Clear();

                List<ServiceReference.Employee> tmpEmpList = service.getEmployees();
                List<ServiceReference.Department> tmpDepList = service.getDepartaments();
                List<ServiceReference.Worker> tmpWorkersList = service.getWorkers();

                foreach(ServiceReference.Employee emp in tmpEmpList)
                {
                    employee = new Employee(emp.UUID, emp.FirstName, emp.LastName, emp.Email, emp.Phone);
                    employeeList.Add(employee);
                }

                foreach(ServiceReference.Department dep in tmpDepList)
                {
                    department = new Department(dep.UUID, dep.DepartmentName);
                    departmentList.Add(department);
                }

                foreach(ServiceReference.Worker wk in tmpWorkersList)
                {
                    employee = new Employee();
                    department = new Department();
                    employee = employeeList.Find(x => x.UUID == wk.EmployeeId);
                    department = departmentList.Find(d => d.UUID == wk.DepartamentId);
                    worker = new Worker(wk.Id, employee, department);
                    workersList.Add(worker);
                }
            }
            catch (Exception)
            {
            }

        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewTotal.SelectedItem != null)
            {
                Worker item = (Worker)ListViewTotal.SelectedItem;
                EditEmployee editEmployee = new EditEmployee(this, item, employeeList, departmentList);
                editEmployee.Show();
            }
            else
                MessageBox.Show("Please, select item.", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            EditEmployee editEmployee = new EditEmployee(this, employeeList, departmentList);
            editEmployee.Show();
        }

        private void ListViewTotal_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Worker item = (Worker)ListViewTotal.SelectedItem;
            EditEmployee editEmployee = new EditEmployee(this, item, employeeList, departmentList);
            editEmployee.Show();
        }

        private void RemoveEmployee_Click(object sender, RoutedEventArgs e)
        {
            Worker item = (Worker)ListViewTotal.SelectedItem;
            if (item != null)
                SQLer.RemoveWorkers(item.Id);
            else
                MessageBox.Show("Please, select item.", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

            ResetWorkersList();
        }

        public void ResetWorkersList()
        {
            workersList.Clear();
            SQLer.ExecuteWorkers(workersList, departmentList, employeeList);
        }
    }
}
