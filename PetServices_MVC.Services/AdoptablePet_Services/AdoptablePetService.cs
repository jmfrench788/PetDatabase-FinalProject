using Microsoft.EntityFrameworkCore;
using PetServices_MVC.Data.Data;
using PetServices_MVC.Models.AdoptablePetsModels;
using PetServices_MVC.Models.PetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetServices_MVC.Services.AdoptablePet_Services
{
    public class AdoptablePetService : IAdoptablePetService
    {
        private ApplicationDbContext _context;

        public AdoptablePetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAdoptablePet(AdoptablePetCreate model)
        {
            AdoptablePet pet = new AdoptablePet()
            {
                Name = model.Name,
                DateRegistered = model.DateRegistered,
                TypeId = model.TypeId,
                Age = model.Age,
                Weight = model.Weight,
                AdoptionStatus = "Not Adopted"
                
            };

            _context.AdoptablePets.Add(pet);
            return await _context.SaveChangesAsync() == 1;

        }

        public async Task<bool> DeleteAdoptablePet(int id)
        {
            AdoptablePet pet = await _context.AdoptablePets.FindAsync(id);

            if (pet == null)
            {
                return false;
            }
            _context.AdoptablePets.Remove(pet);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<AdoptablePetDetail> GetAdoptablePetById(int id)
        {
            AdoptablePet pet = await _context
            .AdoptablePets.Include(r => r.PetType)
            .FirstOrDefaultAsync(r => r.Id == id);

            if (pet == null)
            {
                return null;
            }

            AdoptablePetDetail petDetail = new AdoptablePetDetail
            {
                Id = pet.Id,
                Name = pet.Name,
                TypeId = pet.TypeId,
                PetType = pet.PetType,
                DateRegistered = pet.DateRegistered,
                Age = pet.Age,
                Weight = pet.Weight,
                AdoptionStatus = pet.AdoptionStatus,
                
            };

            return petDetail;
        }

        public async Task<List<AdoptablePetIndex>> GetAllAdoptablePets()
        {
            List<AdoptablePetIndex> pets = await _context.AdoptablePets
                .Include(r => r.PetType)
                .Select(r => new AdoptablePetIndex()
                {
                    Id = r.Id,
                    Name = r.Name,
                    PetType = r.PetType,
                    AdoptionStatus = r.AdoptionStatus,
                }).ToListAsync();

            return pets;
        }

        public async Task<bool> UpdateAdoptablePet(AdoptablePetEdit model)
        {
            if (model == null) return false;

            AdoptablePet pet = await _context.AdoptablePets.FindAsync(model.Id);

            pet.Id = model.Id;
            pet.Name = model.Name;
            pet.Weight = model.Weight;
            pet.Age = model.Age;
            pet.AdoptionStatus = model.AdoptionStatus;

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
