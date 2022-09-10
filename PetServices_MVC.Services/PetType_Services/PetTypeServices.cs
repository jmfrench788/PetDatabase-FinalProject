using Microsoft.EntityFrameworkCore;
using PetServices_MVC.Data.Data;
using PetServices_MVC.Models.PetModels;
using PetServices_MVC.Models.PetTypesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetServices_MVC.Services.PetType_Services
{
    public class PetTypeServices : IPetTypeService
    {
        private ApplicationDbContext _context;

        public PetTypeServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePetType(PetTypeCreate model)
        {
            PetType type = new PetType()
            {
                Name = model.Name,
                Description = model.Description,
            };

            _context.PetTypes.Add(type);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<List<PetTypeIndex>> GetAllPetTypes()
        {
            List<PetTypeIndex> types = await _context.PetTypes
          .Select(r => new PetTypeIndex
          {
              Id = r.Id,
              Name = r.Name,
              Description = r.Description,
          }).ToListAsync();

            return types;
        }

        public async Task<PetTypeDetail> GetTypeById(int id)
        {
            PetType type = await _context.PetTypes.FirstOrDefaultAsync(r => r.Id == id);

            if (type == null)
            {
                return null;
            }

            PetTypeDetail typeDetail = new PetTypeDetail
            {
                Id = type.Id,
                Name = type.Name,
                
                
            };

            return typeDetail;
        }

        public async Task<bool> UpdatePetType(PetTypeEdit model)
        {
            {
                if (model == null) return false;

                PetType type = await _context.PetTypes.FindAsync(model.Id);

                type.Id = model.Id;
                type.Name = model.Name;
                type.Description = model.Description;

                return await _context.SaveChangesAsync() == 1;
            }
        }
    }
}
