using Client_Emias.AdminPages;
using Client_Emias.viewModels.Admins;
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
using System.Windows.Shapes;

namespace Client_Emias
{
    /// <summary>
    /// Логика взаимодействия для MainWindowAdmin.xaml
    /// </summary>
    public partial class MainWindowAdmin : Window
    {
        private AdminViewModel adminViewModel;
        bool isDark = false;

        public MainWindowAdmin()
        {
            adminViewModel = new AdminViewModel();
            InitializeComponent();
            MainFrame.Content = new PatientPage(adminViewModel);
        }

        private void ThemeChange_Click(object sender, RoutedEventArgs e)
        {

            if (!isDark)
            {
                App.Theme = "DarkTheme";
            }

            else
            {
                App.Theme = "LightTheme";
            }
            isDark = !isDark;
            return;
        }

        private void MinimizeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void FullWindowButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
