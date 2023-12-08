using GreenThumb.Database;
using GreenThumb.Managers;
using GreenThumb.Models;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb.Windows
{
    /// <summary>
    /// Interaction logic for PlantDetailsWindow.xaml
    /// </summary>
    public partial class PlantDetailsWindow : Window
    {
        private int plantId;
        private PlantModel currentplant;
        public PlantDetailsWindow(PlantModel plant)
        {
            InitializeComponent();

            currentplant = plant;

            plantId = plant.PlantId;

            lblPlantName.Content = plant.Name;
            txtDescription.Text = plant.Description;

            GetInstructions();

        }
        public async void GetInstructions()
        {
            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                var plantInstructions = await uow.InstructionRepository.GetAllAsync();

                var filteredInstructions = plantInstructions.Where(i => i.PlantId == plantId);

                foreach (var plantInstruction in filteredInstructions)
                {
                    ListViewItem item = new();
                    item.Tag = plantInstruction;
                    item.Content = plantInstruction.Text;

                    lvInstructions.Items.Add(item);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new();
            plantWindow.Show();
            Close();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                try
                {
                    int gardenId = UserManager.signedInUser.GardenId ?? 0;

                    PlantGarden userPlantGarden = new()
                    {
                        PlantId = currentplant.PlantId,
                        GardenId = gardenId
                    };

                    await uow.PlantGardenRepository.Add(userPlantGarden);
                    await uow.Complete();

                    PlantWindow plantWindow = new();
                    plantWindow.Show();
                    Close();
                }
                catch
                {
                    MessageBox.Show("That plant is already in your garden.");
                }

            }
        }
    }
}
