using GreenThumb.Database;
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
        public PlantDetailsWindow(PlantModel plant)
        {
            InitializeComponent();

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
