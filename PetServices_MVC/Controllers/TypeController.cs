using Microsoft.AspNetCore.Mvc;
using PetServices_MVC.Models.PetModels;
using PetServices_MVC.Models.PetTypesModels;
using PetServices_MVC.Services.PetService_Services;
using PetServices_MVC.Services.PetType_Services;

namespace PetServices_MVC.Controllers
{
    public class TypeController : Controller
    {
        public IPetTypeService _service;

        public TypeController(IPetTypeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<PetTypeIndex> types = await _service.GetAllPetTypes();
            return View(types);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetTypeCreate petTypeCreate)
        {
            if (petTypeCreate == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _service.CreatePetType(petTypeCreate))
                return RedirectToAction(nameof(Index));
            else
                return View(petTypeCreate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PetTypeEdit typeEdit)
        {
            if (typeEdit == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _service.UpdatePetType(typeEdit))
                return RedirectToAction(nameof(Index));
            else
                return View(typeEdit);
        }

        public async Task<IActionResult> Edit(int id)
        {
            PetTypeDetail pet = await _service.GetTypeById(id);
            return View(pet);


        }
    }
}
