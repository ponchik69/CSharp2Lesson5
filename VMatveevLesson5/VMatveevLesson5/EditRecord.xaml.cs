using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace VMatveevLesson5
{
    /// <summary>
    /// Логика взаимодействия для EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        private MainWindow parent;
        List<Employee> employees;
        List<Department> departments;

        public EditEmployee(MainWindow mainForm)
        {
            parent = mainForm;

            InitializeComponent();

            EmployeeComboBox.ItemsSource = parent.organizattion.eList.employeeList;
            DepartamentComboBox.ItemsSource = parent.organizattion.dList.departmentList;

        }

        public EditEmployee(MainWindow mainForm, Worker item)
        {
            parent = mainForm;
            employees = new List<Employee>();
            departments = new List<Department>();
            employees.Add(item.Employee);
            departments = parent.organizattion.dList.departmentList;

            InitializeComponent();
            

            EmployeeComboBox.ItemsSource = employees;
            EmployeeComboBox.SelectedIndex = 0;
            DepartamentComboBox.ItemsSource = departments;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Employee tmpEmp = (Employee)EmployeeComboBox.SelectedValue;
            Department tmpDep = (Department)DepartamentComboBox.SelectedValue;

            if(tmpEmp != null && tmpDep != null)
            {
                var result = from f
             in parent.workersList
                             where f.Employee.UUID == tmpEmp.UUID
                             select f;

                foreach (Worker a in result)
                {
                    a.Department = tmpDep;
                }

                parent.ListViewTotal.Items.Refresh();
            }
            else
                MessageBox.Show("Employee or departament can't be null!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
