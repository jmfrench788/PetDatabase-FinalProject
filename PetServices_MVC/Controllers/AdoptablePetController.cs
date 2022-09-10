using Microsoft.AspNetCore.Mvc;
using PetServices_MVC.Models.AdoptablePetsModels;
using PetServices_MVC.Services.AdoptablePet_Services;


namespace PetServices_MVC.Controllers
{
    public class AdoptablePetController : Controller
    {
        public IAdoptablePetService _service;

        public AdoptablePetController(IAdoptablePetService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdoptablePetCreate petCreate)
        {
            if (petCreate == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _service.CreateAdoptablePet(petCreate))
                return RedirectToAction(nameof(Index));
            else
                return View(petCreate);
        }

        [ActionName("Details")]
        public async Task<IActionResult> Details(int id)
        {
            AdoptablePetDetail pet = await _service.GetAdoptablePetById(id);
            return View(pet);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdoptablePetEdit petEdit)
        {
            if (petEdit == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _service.UpdateAdoptablePet(petEdit))
                return RedirectToAction(nameof(Index));
            else
                return View(petEdit);
        }

        public async Task<IActionResult> Edit(int id)
        {
            AdoptablePetDetail pet = await _service.GetAdoptablePetById(id);
            return View(pet);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAdoptablePet(id);
            return View(Delete);
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> GetAdoptablePets()
        {
            List<AdoptablePetIndex> pets = await _service.GetAllAdoptablePets();
            return Json(new { data = pets });
        }
        #endregion
    }
}
