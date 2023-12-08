using GreenThumb.Database;
using GreenThumb.Managers;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;

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

            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                var filteredPlants = context.PlantGardens.Where(p => p.GardenId == UserManager.signedInUser.GardenId).Include(p => p.Plant).ToList();

                foreach (var plant in filteredPlants)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.Plant.Name;

                    lvPlants.Items.Add(item);
                }

                //var filteredPlants = context.Plants.Where(p => p.Name.ToLower().Contains(searchText)).ToList();
            }
        }

        private void DisplayUsername()
        {
            lblUsername.Content = UserManager.signedInUser.Username;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new();
            plantWindow.Show();
            Close();
        }
    }
}
