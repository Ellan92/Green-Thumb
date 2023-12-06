using GreenThumb.Managers;
using System.Windows;

namespace GreenThumb.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //PlantWindow plantWindow = new PlantWindow();
            //plantWindow.Show();
            //Close();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            bool isSuccessfulLogin = await UserManager.SigninUser(username, password);

            if (isSuccessfulLogin)
            {
                PlantWindow plantWindow = new();
                plantWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("User does not exist, please try again.");
            }
        }
    }
}
