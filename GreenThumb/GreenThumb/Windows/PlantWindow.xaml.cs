using GreenThumb.Database;
using GreenThumb.Managers;
using GreenThumb.Models;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb.Windows
{
    /// <summary>
    /// Interaction logic for PlantWindow.xaml
    /// </summary>
    public partial class PlantWindow : Window
    {
        public PlantWindow()
        {
            InitializeComponent();
            UpdateUi();
            DisplayUsername();
        }
        public async Task UpdateUi()
        {
            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                var allPlants = await uow.PlantRepository.GetAllAsync();

                foreach (var plant in allPlants)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.Name;

                    lvPlants.Items.Add(item);
                }
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                if (lvPlants.SelectedItem != null)
                {
                    ListViewItem selectedItem = (ListViewItem)lvPlants.SelectedItem;
                    PlantModel selectedPlant = (PlantModel)selectedItem.Tag;

                    await uow.PlantRepository.DeleteAsync(selectedPlant.PlantId);
                    lvPlants.Items.Remove(selectedItem);
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("You need to select a plant first!");
                }

            }
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            using (GreenThumbDbContext context = new())
            {

                if (lvPlants.SelectedItem != null)
                {
                    ListViewItem selectedItem = (ListViewItem)lvPlants.SelectedItem;
                    PlantModel selectedPlant = (PlantModel)selectedItem.Tag;

                    PlantDetailsWindow plantDetailsWindow = new(selectedPlant);
                    plantDetailsWindow.Show();
                    Close();

                }
                else
                {
                    MessageBox.Show("You need to select a plant first!");
                }
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPlantWindow addPlantWindow = new();
            addPlantWindow.Show();
            Close();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (GreenThumbDbContext context = new())
            {
                string searchText = txtSearch.Text.ToLower();

                var filteredPlants = context.Plants.Where(p => p.Name.ToLower().Contains(searchText)).ToList();
                //var filteredPlants = context.Plants.Where(p => p.Name.StartsWith(searchText, StringComparison.OrdinalIgnoreCase)).ToList();

                lvPlants.Items.Clear();

                foreach (var plant in filteredPlants)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.Name;
                    lvPlants.Items.Add(item);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignOutUser();
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
        private void DisplayUsername()
        {
            lblUsername.Content = UserManager.signedInUser.Username;
        }
    }
}
