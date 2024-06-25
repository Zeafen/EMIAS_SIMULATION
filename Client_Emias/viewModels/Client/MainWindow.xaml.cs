using Client_Emias.viewModels.Client;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client_Emias
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Patient_Click(object sender, RoutedEventArgs e)
        {
            PatientMain window = new PatientMain();
            window.Show();
            Close();
        }

        private void Doctor_Click(object sender, RoutedEventArgs e)
        {
            DoctorMain window = new DoctorMain();
            window.Show();
            Close();
        }
    }
}