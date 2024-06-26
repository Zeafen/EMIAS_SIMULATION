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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client_Emias.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для DoctorPage.xaml
    /// </summary>
    public partial class DoctorPage : Page
    {
        public AdminViewModel adminVm { get; set; }
        public DoctorPage(AdminViewModel _VM)
        {
            this.adminVm = _VM;
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            adminVm.UpdateSource();
            string selectedRole = (RolesComboBox.SelectedItem as ComboBoxItem).Content.ToString();

            if (selectedRole == "Пользователь")
                (Application.Current.MainWindow as MainWindowAdmin).MainFrame.Content = new PatientPage(adminVm);
            else if (selectedRole == "Администратор")
                (Application.Current.MainWindow as MainWindowAdmin).MainFrame.Content = new AdminPage(adminVm);
        }
    }
}
