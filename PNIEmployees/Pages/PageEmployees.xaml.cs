using PNIEmployees.DataFilesApp;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для PageEmployees.xaml
    /// </summary>
    public partial class PageEmployees : Page
    {
        public PageEmployees()
        {
            InitializeComponent();
            EmployeeGrid.ItemsSource = DBHelper.entObj.Employees.ToList();
            PostsGrid.ItemsSource = DBHelper.entObj.Posts.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.frmObj.Navigate(new PageEditEmpl((sender as Button).DataContext as Employees));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.frmObj.Navigate(new PageEditEmpl(null));
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.frmObj.Navigate(new PageLogin());
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var employeesForRemoving = EmployeeGrid.SelectedItems.Cast<Employees>().ToList();
            if (MessageBox.Show($"Вы действительно хотите удалить сделующие {employeesForRemoving.Count()} сотрудников?",
                    "Внимание",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DBHelper.entObj.Employees.RemoveRange(employeesForRemoving);
                    DBHelper.entObj.SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    EmployeeGrid.ItemsSource = DBHelper.entObj.Employees.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void AddEmpBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.frmObj.Navigate(new PageEditPosts(null));
        }

        private void EditBtn_Click_1(object sender, RoutedEventArgs e)
        {
            FrameHelper.frmObj.Navigate(new PageEditPosts((sender as Button).DataContext as Posts));
        }

        private void DelPostBtn_Click(object sender, RoutedEventArgs e)
        {
            var postsForRemoving = PostsGrid.SelectedItems.Cast<Posts>().ToList();
            if (MessageBox.Show($"Вы действительно хотите удалить сделующие {postsForRemoving.Count()} должностей?",
                    "Внимание",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DBHelper.entObj.Posts.RemoveRange(postsForRemoving);
                    DBHelper.entObj.SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    PostsGrid.ItemsSource = DBHelper.entObj.Posts.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}