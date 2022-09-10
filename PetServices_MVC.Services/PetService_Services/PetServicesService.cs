using Microsoft.EntityFrameworkCore;
using PetServices_MVC.Data.Data;
using PetServices_MVC.Models.PetModels;
using PetServices_MVC.Models.PetServicesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetServices_MVC.Services.PetService_Services
{
    public class PetServicesService : IPetServicesService
    {
        private ApplicationDbContext _context;

        public PetServicesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateService(PetServiceCreate model)
        {
            PetService_ service = new PetService_()
            {
                Name = model.Name,
                Description = model.Description,
            };

            _context.PetServices.Add(service);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteService(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PetServiceIndex>> GetAllServices()
        {
            List<PetServiceIndex> petServices = await _context.PetServices
             .Select(r => new PetServiceIndex
             {
                 Id = r.Id,
                 Name = r.Name,
                 Description = r.Description,
             }).ToListAsync();

            return petServices;
        }

        public async Task<PetServiceDetail> GetServiceById(int id)
        {
            PetService_ service = await _context.PetServices.FirstOrDefaultAsync(r => r.Id == id);

            if (service == null)
            {
                return null;
            }

            PetServiceDetail serviceDetail = new PetServiceDetail
            {
                Id = service.Id,
                Name = service.Name,


            };

            return serviceDetail;
        }

        public async Task<bool> UpdateService(PetServiceEdit model)
        {
            if (model == null) return false;

            PetService_ service = await _context.PetServices.FindAsync(model.Id);

            service.Id = model.Id;
            service.Name = model.Name;
            service.Description = model.Description;

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
