using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VMatveevLesson5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Worker> workersList { get; set; }
        public EList eList = new EList();
        public DList dList = new DList();
        Employee employee;
        Department department;
        Worker worker;

        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();

            workersList = new ObservableCollection<Worker>();

            for (int i = 0; i < eList.employeeList.Count; i++)
            {

                employee = eList.employeeList[i];
                department = dList.departmentList[rnd.Next(0, dList.departmentList.Count)];
                worker = new Worker();
                worker.Employee = employee;
                worker.Department = department;
                workersList.Add(worker);
            }

            DataContext = this;
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            EditEmployee editEmployee = new EditEmployee(this);
            editEmployee.Show();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            employee = new Employee();
            employee.FirstName = MegaGenerator.GetEmployeeName();
            employee.LastName = MegaGenerator.GetEmployeeLastname();
            eList.employeeList.Add(employee);

            department = new Department();
            department.DepartmentName = MegaGenerator.GetDepartamentName();
            dList.departmentList.Add(department);

            worker = new Worker();
            worker.Department = department;
            worker.Employee = employee;
            workersList.Add(worker);
        }
    }
}
