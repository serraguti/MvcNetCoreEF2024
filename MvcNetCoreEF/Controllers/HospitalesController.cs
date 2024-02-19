using Microsoft.AspNetCore.Mvc;
using MvcNetCoreEF.Models;
using MvcNetCoreEF.Repositories;

namespace MvcNetCoreEF.Controllers
{
    public class HospitalesController : Controller
    {
        private RepositoryHospital repo;

        public HospitalesController(RepositoryHospital repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }

        public IActionResult Details(int idhospital)
        {
            Hospital hospital = this.repo.FindHospital(idhospital);
            return View(hospital);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hospital hospital)
        {
            this.repo.InsertHospital(hospital.IdHospital, hospital.Nombre
                , hospital.Direccion, hospital.Telefono, hospital.Camas);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            this.repo.DeleteHospital(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Hospital hospital = this.repo.FindHospital(id);
            return View(hospital);
        }

        [HttpPost]
        public IActionResult Edit(Hospital hospital)
        {
            this.repo.UpdateHospital(hospital.IdHospital, hospital.Nombre
                , hospital.Direccion, hospital.Telefono, hospital.Camas);
            return RedirectToAction("Index");
        }
    }
}
