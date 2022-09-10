using Microsoft.AspNetCore.Mvc;
using PetServices_MVC.Models.PetModels;
using PetServices_MVC.Models.PetServicesModels;
using PetServices_MVC.Models.PetTypesModels;
using PetServices_MVC.Services.Pet_Services;
using PetServices_MVC.Services.PetService_Services;

namespace PetServices_MVC.Controllers
{
    public class ServiceController : Controller
    {
     

        public IPetServicesService _service;

        public ServiceController(IPetServicesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<PetServiceIndex> petServices = await _service.GetAllServices();
            return View(petServices);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetServiceCreate petServiceCreate)
        {
            if(petServiceCreate == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _service.CreateService(petServiceCreate))
                return RedirectToAction(nameof(Index));
              else
                return View(petServiceCreate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PetServiceEdit serviceEdit)
        {
            if (serviceEdit == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _service.UpdateService(serviceEdit))
                return RedirectToAction(nameof(Index));
            else
                return View(serviceEdit);
        }

        public async Task<IActionResult> Edit(int id)
        {
            PetServiceDetail pet = await _service.GetServiceById(id);
            return View(pet);


        }
    }
}
