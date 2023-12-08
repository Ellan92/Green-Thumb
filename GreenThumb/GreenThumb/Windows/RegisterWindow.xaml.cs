using GreenThumb.Database;
using GreenThumb.Managers;
using GreenThumb.Models;
using System.Windows;

namespace GreenThumb.Windows
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                if (!string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(txtPassword.Password))
                {
                    string username = txtUsername.Text;
                    string password = txtPassword.Password;

                    if (await UserManager.ValidateUsername(username) != false)
                    {
                        GardenModel newGarden = new()
                        {
                            Name = $"{txtUsername.Text}'s Garden"
                        };
                        UserModel newUser = new()
                        {
                            Username = username,
                            Password = password,
                            Garden = newGarden
                        };

                        await uow.GardenRepository.Add(newGarden);
                        await uow.UserRepository.Add(newUser);
                        await uow.Complete();

                        UserManager.signedInUser = newUser;

                        //await UserManager.RegisterUser(username, password);

                        PlantWindow plantWindow = new();
                        plantWindow.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Username already taken, try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Some of the fields are empty, try again.");
                }

            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }
}
