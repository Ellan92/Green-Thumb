using GreenThumb.Database;
using GreenThumb.Models;
using System.Windows;

namespace GreenThumb.Windows
{
    /// <summary>
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window
    {
        public List<string> Instructions = new();
        public AddPlantWindow()
        {
            InitializeComponent();


        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (GreenThumbDbContext context = new())
            {
                string plantName = txtPlantName.Text.ToLower();
                string description = txtDescription.Text;

                if (!string.IsNullOrWhiteSpace(txtPlantName.Text) && !string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    GreenThumbUow uow = new(context);

                    var allPlants = await uow.PlantRepository.GetAllAsync();

                    PlantModel newPlant = new()
                    {
                        Name = plantName,
                        Description = description
                    };

                    if (!allPlants.Any(p => p.Name.ToLower() == plantName))
                    {


                        await uow.PlantRepository.Add(newPlant);
                        await uow.Complete();

                        foreach (string Instruction in Instructions)
                        {
                            InstructionModel newInstruction = new()
                            {
                                Text = Instruction,
                                PlantId = newPlant.PlantId,
                            };

                            //newPlant.Instructions.Add(newInstruction);
                            await uow.InstructionRepository.Add(newInstruction);
                        }
                        await uow.Complete();

                        MessageBox.Show("Plant added!");

                        ClearUi();
                    }
                    else
                    {
                        MessageBox.Show("A plant with that name already exists, try again.");
                    }

                }
                else
                {
                    MessageBox.Show("Some of the fields are empty..");
                }
            }
        }

        private void btnAddInstruction_Click(object sender, RoutedEventArgs e)
        {
            using (GreenThumbDbContext context = new())
            {
                if (!string.IsNullOrWhiteSpace(txtAddInstruction.Text))
                {
                    GreenThumbUow uow = new(context);

                    string newInstruction = txtAddInstruction.Text;
                    Instructions.Add(newInstruction);

                    lvInstructions.Items.Clear();

                    foreach (string instruction in Instructions)
                    {
                        lvInstructions.Items.Add(instruction);
                    }
                }
            }
        }

        private void ClearUi()
        {
            lvInstructions.Items.Clear();
            txtAddInstruction.Clear();
            txtDescription.Clear();
            txtPlantName.Clear();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new();
            plantWindow.Show();
            Close();
        }
    }
}
