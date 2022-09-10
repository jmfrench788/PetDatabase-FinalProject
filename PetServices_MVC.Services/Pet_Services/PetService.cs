using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetServices_MVC.Data.Data;
using PetServices_MVC.Models.PetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetServices_MVC.Services.Pet_Services
{
    public class PetService : IPetService
    {
        private ApplicationDbContext _context;
      
        public PetService(ApplicationDbContext context)
        {
            _context = context;
        }

    


        public async Task<bool> CreatePet(PetCreate model)
        {
            Pet pet = new Pet()
            {
                Name = model.Name,
                DateRegistered = model.DateRegistered,
                TypeId = model.TypeId,
                Age = model.Age,
                Weight = model.Weight,
                ServiceId = model.ServiceId,
            };

            _context.Pets.Add(pet);
            return await _context.SaveChangesAsync() == 1;

           
        }

        public async Task<bool> DeletePet(int id)
        {
            Pet pet = await _context.Pets.FindAsync(id);

            if (pet == null)
            {
                return false;
            }
            _context.Pets.Remove(pet);
            return await _context.SaveChangesAsync() == 1;
            
        }

        public async Task<List<PetListItem>> GetAllPets()
        {
            List<PetListItem> pets = await _context.Pets
                .Include(r => r.CurrentService)
                .Select(r => new PetListItem()
                {
                    Id = r.Id,
                    Name = r.Name,
                    PetType = r.PetType,
                    CurrentService = r.CurrentService,
                }).ToListAsync();

            return pets;
        }

        public async Task<PetDetail> GetPetById(int id)
        {
           

            Pet pet = await _context
                .Pets.Include(r => r.CurrentService).Include(r => r.PetType)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (pet == null)
            {
                return null;
            }

            PetDetail petDetail = new PetDetail
            {
                Id = pet.Id,
                Name = pet.Name,
                TypeId = pet.TypeId,
                PetType = pet.PetType,
                DateRegistered = pet.DateRegistered,
                Age = pet.Age,
                Weight = pet.Weight,
                ServiceId = pet.ServiceId,
                CurrentService = pet.CurrentService,
            };

            return petDetail;
        }

        public async Task<List<PetListItem>> SearchPets(string name)
        {
            List<PetListItem> pets = await _context.Pets
                .Where(r => r.Name == name)
                .Select(r => new PetListItem()
                {
                    Id = r.Id,
                    Name = r.Name,
                    PetType = r.PetType,
                    CurrentService = r.CurrentService,
                }).ToListAsync();

            return pets;
        }

        public async Task<bool> UpdatePet(PetEdit model)
        {
            if (model == null) return false;

            Pet pet = await _context.Pets.FindAsync(model.Id);

            pet.Id = model.Id;
            pet.Name = model.Name;
            pet.Weight = model.Weight;
            pet.Age = model.Age;
            pet.ServiceId = model.ServiceId;

            return await _context.SaveChangesAsync() == 1;
        }


    }
}
