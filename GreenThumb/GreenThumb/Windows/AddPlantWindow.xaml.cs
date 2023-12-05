using GreenThumb.Database;
using GreenThumb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
                if(!string.IsNullOrWhiteSpace(txtPlantName.Text) && !string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    GreenThumbUow uow = new(context);


                    PlantModel newPlant = new()
                    {
                        Name = txtPlantName.Text,
                        Description = txtDescription.Text,
                    };

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

                    foreach(string instruction in Instructions)
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
