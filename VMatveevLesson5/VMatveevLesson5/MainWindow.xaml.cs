using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;


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

            SQLer.ExecuteEmployee(employeeList);
            SQLer.ExecuteDepartament(departmentList);
            SQLer.ExecuteWorkers(workersList, departmentList, employeeList);

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

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if(ListViewTotal.SelectedItem != null)
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
