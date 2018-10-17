using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace VMatveevLesson5
{
    /// <summary>
    /// Логика взаимодействия для EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        MainWindow parent;
        bool editFlag = false;
        int itemId;
        

        public EditEmployee(MainWindow mainForm)
        {
            parent = mainForm;
            InitializeComponent();
        }

        public EditEmployee(MainWindow mainForm, List<Employee> employeeList, List<Department> departmentList)
        {
            parent = mainForm;
            InitializeComponent();

            EmployeeComboBox.ItemsSource = employeeList;
            DepartamentComboBox.ItemsSource = departmentList;
            editFlag = false;
        }

        public EditEmployee(MainWindow mainForm, Worker item, List<Employee> employeeList, List<Department> departmentList)
        {
            parent = mainForm;
            InitializeComponent();

            EmployeeComboBox.ItemsSource = employeeList;
            DepartamentComboBox.ItemsSource = departmentList;
            EmployeeComboBox.SelectedItem = item.Employee;
            itemId = item.Id;
            editFlag = true;
        }

        public void EditItem()
        {
            Employee tmpEmp = (Employee)EmployeeComboBox.SelectedValue;
            Department tmpDep = (Department)DepartamentComboBox.SelectedValue;

            if (tmpEmp != null && tmpDep != null)
            {
                var result = from f 
                             in parent.workersList
                             where f.Employee.UUID == tmpEmp.UUID
                             select f;

                foreach (Worker a in result)
                {
                    a.Department = tmpDep;
                }
                SQLer.UpdateWorkers(itemId, tmpEmp.UUID, tmpDep.UUID);
                parent.ResetWorkersList();
                parent.ListViewTotal.Items.Refresh();
            }
            else
                MessageBox.Show("Employee or departament can't be null!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }

        public void AddItem()
        {
            Employee tmpEmp = (Employee)EmployeeComboBox.SelectedValue;
            Department tmpDep = (Department)DepartamentComboBox.SelectedValue;

            if (tmpEmp != null && tmpDep != null)
            {
                SQLer.InserntWorkers(tmpEmp.UUID, tmpDep.UUID);
                parent.ResetWorkersList();
                parent.ListViewTotal.Items.Refresh();
            }
            else
                MessageBox.Show("Employee or departament can't be null!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (editFlag == true)
                EditItem();
            else
                AddItem();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
