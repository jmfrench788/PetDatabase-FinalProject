using PetServices_MVC.Models.AdoptablePetsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetServices_MVC.Services.AdoptablePet_Services
{
    public interface IAdoptablePetService 
    {
        Task<bool> CreateAdoptablePet(AdoptablePetCreate model);
        Task<List<AdoptablePetIndex>> GetAllAdoptablePets();
        Task<AdoptablePetDetail> GetAdoptablePetById(int id);
        Task<bool> UpdateAdoptablePet(AdoptablePetEdit model);
        Task<bool> DeleteAdoptablePet(int id);
    }
}
