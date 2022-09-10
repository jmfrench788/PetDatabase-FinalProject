using Microsoft.AspNetCore.Mvc;
using PetServices_MVC.Models.PetModels;
using PetServices_MVC.Services.Pet_Services;
using System.Collections.Generic;

namespace PetServices_MVC.Controllers
{
    public class PetController : Controller
    {
        public IPetService _service;

        public PetController(IPetService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            //List<PetListItem> pets = await _service.GetAllPets();
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Index(string id)
        //{
        //    if(id == null)
        //    {
        //        List<PetListItem> pets = await _service.GetAllPets();
        //        return View(pets);
        //    }
        //    else
        //    {
        //        List<PetListItem> search = await _service.SearchPets(id);
        //        return View(search);
        //    }

        //}

        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetCreate petCreate)
        {
            if (petCreate == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _service.CreatePet(petCreate))
                return RedirectToAction(nameof(Index));
            else
                return View(petCreate);
        }

        [ActionName("Details")]
        public async Task<IActionResult> Details(int id)
        {
            PetDetail pet = await _service.GetPetById(id);
            return View(pet);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PetEdit petEdit)
        {
            if (petEdit == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _service.UpdatePet(petEdit))
                return RedirectToAction(nameof(Index));
            else
                return View(petEdit);
        }

        public async Task<IActionResult> Edit(int id)
        {
            PetDetail pet = await _service.GetPetById(id);
            return View(pet);

            
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePet(id);
            return View(Delete);
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> GetPets()
        {
            List<PetListItem> pets = await _service.GetAllPets();
            return Json(new {data=pets});
        }
        #endregion

    }
}
