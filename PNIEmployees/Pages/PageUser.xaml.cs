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
    /// Логика взаимодействия для PageUser.xaml
    /// </summary>
    public partial class PageUser : Page
    {
        public PageUser()
        {
            InitializeComponent();
            EmployeeGrid.ItemsSource = DBHelper.entObj.Employees.ToList();
            PostsGrid.ItemsSource = DBHelper.entObj.Posts.ToList();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.frmObj.Navigate(new PageLogin());
        }
    }
}
