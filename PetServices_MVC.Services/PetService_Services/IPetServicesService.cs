using PetServices_MVC.Models.PetModels;
using PetServices_MVC.Models.PetServicesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetServices_MVC.Services.PetService_Services
{
    public interface IPetServicesService
    {
        Task<bool> CreateService(PetServiceCreate model);
        Task<List<PetServiceIndex>> GetAllServices();
        Task<PetServiceDetail> GetServiceById(int id);
        Task<bool> UpdateService(PetServiceEdit model);
        Task<bool> DeleteService(int id);
    }
}
