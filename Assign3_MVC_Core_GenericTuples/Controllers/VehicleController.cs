using Assign3_MVC_Core_GenericTuples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assign3_MVC_Core_GenericTuples.Controllers
{
    public class VehicleController : Controller
    {
        // GET: VehicleController
        public ActionResult Index()
        {
            return View(VehicleData.vehicles);
        }

        // GET: VehicleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, string brand, string model, int year, decimal price)
        {
            VehicleData.vehicles.Add(new Tuple<int, string, string, int, decimal>(id, brand, model, year, price));
            return RedirectToAction("Index");
        }

        // GET: VehicleController/Edit/5
        public ActionResult Edit(int id)
        {
            var vehicle = VehicleData.vehicles.Find(v => v.Item1 == id);
            return View(vehicle);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string brand, string model, int year, decimal price)
        {
            var vehicle = VehicleData.vehicles.Find(v => v.Item1 == id);
            VehicleData.vehicles.Remove(vehicle);

            VehicleData.vehicles.Add(new Tuple<int, string, string, int, decimal>(id, brand, model, year, price));
            return RedirectToAction("Index");
        }

       
        public ActionResult Delete(int id)
        {
            var vehicle = VehicleData.vehicles.Find(v => v.Item1 == id);
            VehicleData.vehicles.Remove(vehicle);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
