using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;
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
        public Organizattion organizattion = new Organizattion();
        Employee employee;
        Department department;
        Worker worker;

        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();

            workersList = new ObservableCollection<Worker>();

            for (int i = 0; i < organizattion.GetEmployeeListCount(); i++)
            {

                employee = organizattion.GetEmployeeListItem(i);
                department = organizattion.GetDepartmentListItem(rnd.Next(0, organizattion.GetDepartmentListCount()));
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

        private void AddRandom_Click(object sender, RoutedEventArgs e)
        {
            employee = new Employee();
            employee.FirstName = MegaGenerator.GetEmployeeName();
            employee.LastName = MegaGenerator.GetEmployeeLastname();
            employee.UUID = organizattion.GetEmployeeListCount();
            organizattion.AddEmployeeListItem(employee);

            department = new Department();
            department.DepartmentName = MegaGenerator.GetDepartamentName();
            organizattion.AddDepartmentListItem(department);

            worker = new Worker();
            worker.Department = department;
            worker.Employee = employee;
            workersList.Add(worker);
        }

        private void ListViewTotal_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
//            var item = ListViewTotal.SelectedItem as Track;
            Worker item = (Worker)ListViewTotal.SelectedItem;
            EditEmployee editEmployee = new EditEmployee(this, item);
            editEmployee.Show();
        }
    }
}
