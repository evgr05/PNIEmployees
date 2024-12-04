using PNIEmployees.DataFilesApp;
using System;
using System.Collections.Generic;
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

namespace PNIEmployees.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEditEmpl.xaml
    /// </summary>
    public partial class PageEditEmpl : Page
    {
        private Employees _currentEmployee = new Employees();
        public PageEditEmpl(Employees _selectedEmployee)
        {
            InitializeComponent();
            if( _selectedEmployee != null)
            {
                _currentEmployee = _selectedEmployee;
            }
            DataContext = _currentEmployee;
            ComboPosts.ItemsSource = DBHelper.entObj.Posts.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentEmployee.LastName))
                errors.AppendLine("Укажите фамилию");
            if (string.IsNullOrWhiteSpace(_currentEmployee.FirstName))
                errors.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Patronymic))
                errors.AppendLine("Укажите отчество");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Phone))
                errors.AppendLine("Укажите телефон");
            if (_currentEmployee.Posts == null)
            {
                errors.AppendLine("Укажите должность");
            }
            if (_currentEmployee.EmploymentDate == null)
                errors.AppendLine("Укажите дату приема на работу");
            if (_currentEmployee.Pay == null)
                errors.AppendLine("Укажите оклад");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Adress))
                errors.AppendLine("Укажите адрес");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if(_currentEmployee.Id == 0)
                {
                    DBHelper.entObj.Employees.Add(_currentEmployee);
                }
                DBHelper.entObj.SaveChanges();
                FrameHelper.frmObj.Navigate(new PageEmployees());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void bckBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.frmObj.Navigate(new PageEmployees());
        }
    }
}
