using GreenThumb.Managers;
using System.Windows;

namespace GreenThumb.Windows
{
    /// <summary>
    /// Interaction logic for MyGardenWindow.xaml
    /// </summary>
    public partial class MyGardenWindow : Window
    {
        public MyGardenWindow()
        {
            InitializeComponent();
            DisplayUsername();
        }

        private void DisplayUsername()
        {
            lblUsername.Content = UserManager.signedInUser.Username;
        }
    }
}
