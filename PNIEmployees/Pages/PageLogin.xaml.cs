﻿using PNIEmployees.DataFilesApp;
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
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = DBHelper.entObj.Users.FirstOrDefault(x => x.Login == txbLogin.Text && x.Password == psbPassword.Password);
                if (userObj != null)
                {
                    if (userObj.RoleId == 1)
                    {
                        FrameHelper.frmObj.Navigate(new PageEmployees());
                    }
                    if (userObj.RoleId == 2)
                    {
                        FrameHelper.frmObj.Navigate(new PageUser());
                    }
                }
                else MessageBox.Show("Неверное имя пользователя или пароль", "Ошибка");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
