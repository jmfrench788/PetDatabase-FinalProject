using Microsoft.AspNetCore.Mvc;
using PetServices_MVC.Models.PetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetServices_MVC.Services.Pet_Services
{
    public interface IPetService
    {
       Task<bool> CreatePet(PetCreate model);
        Task<List<PetListItem>> GetAllPets();
        Task<PetDetail> GetPetById( int id);
        Task<bool> UpdatePet(PetEdit model);
        Task<bool> DeletePet(int id);
        Task<List<PetListItem>> SearchPets(string name);
    }
}
