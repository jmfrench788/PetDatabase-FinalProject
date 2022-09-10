using PetServices_MVC.Models.PetModels;
using PetServices_MVC.Models.PetTypesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetServices_MVC.Services.PetType_Services
{
    public interface IPetTypeService
    {
        Task<bool> CreatePetType(PetTypeCreate model);
        Task<List<PetTypeIndex>> GetAllPetTypes();
        Task<PetTypeDetail> GetTypeById(int id);
        Task<bool> UpdatePetType(PetTypeEdit model);
    }
}
