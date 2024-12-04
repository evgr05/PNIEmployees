using PNIEmployees.DataFilesApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для PageEditPosts.xaml
    /// </summary>
    public partial class PageEditPosts : Page
    {
        private Posts _currentPost = new Posts();
        public PageEditPosts( Posts _SelectedPost)
        {
            InitializeComponent();
            if( _SelectedPost != null)
            {
                _currentPost = _SelectedPost;
            }
            DataContext = _currentPost;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentPost.Name))
                errors.AppendLine("Укажите должность");
            if(_currentPost.Id == 0)
            {
                DBHelper.entObj.Posts.Add(_currentPost);
            }
            try
            {
                DBHelper.entObj.SaveChanges();
                FrameHelper.frmObj.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void bckBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.frmObj.GoBack();
        }
    }
}
