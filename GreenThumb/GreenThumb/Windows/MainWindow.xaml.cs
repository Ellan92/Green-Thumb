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
            string password = txtPassword.Password;

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

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new();
            registerWindow.Show();
            Close();
        }
    }
}
