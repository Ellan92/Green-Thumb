using GreenThumb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Database
{
    internal class GreenThumbUow
    {
        private readonly GreenThumbDbContext _context;
        public GreenThumbRepository<PlantModel> PlantRepository { get; }
        public GreenThumbRepository<InstructionModel> InstructionRepository { get; }
        public GreenThumbRepository<GardenModel> GardenRepository { get; }
        public GreenThumbRepository<UserModel> UserRepository { get; }
        public GreenThumbUow(GreenThumbDbContext context)
        {
            _context = context;

            PlantRepository = new(context);
            InstructionRepository = new(context);
            GardenRepository = new(context);
            UserRepository = new(context);
        }
        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }


    }
}
