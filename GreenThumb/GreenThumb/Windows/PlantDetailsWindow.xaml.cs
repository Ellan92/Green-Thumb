using GreenThumb.Database;
using GreenThumb.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            


            //lvInstructions.ItemsSource = instructionStrings;

            //foreach (var instruction in instructions)
            //{
            //    ListViewItem item = new();
            //    item.Tag = instruction;
            //    item.Content = instructions.ToList();
            //    lvInstructions.Items.Add(instructions);
            //}

        }
    }
}
