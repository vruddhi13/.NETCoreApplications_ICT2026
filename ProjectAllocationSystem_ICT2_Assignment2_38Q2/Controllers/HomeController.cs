using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectAllocationSystem_ICT2_Assignment2_38Q2.GenericCollection;
using ProjectAllocationSystem_ICT2_Assignment2_38Q2.Models;

namespace ProjectAllocationSystem_ICT2_Assignment2_38Q2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProjectAllocationDbContext _logger;

        public HomeController(ProjectAllocationDbContext logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var empList = _logger.Employees.ToList();
            EmployeeIndexer indexer = new EmployeeIndexer(empList);

            var deptEmployees = indexer["IT"];
            Console.WriteLine("Employees in it department: ");

            foreach (var e in deptEmployees)
            {
                Console.WriteLine(e.EmpName);
            }

            Console.WriteLine("IT Department - Software Developer Designation:");
            var deptDesignationEmp = indexer["IT", "Software Developer"];

            foreach (var e in deptDesignationEmp)
            {
                Console.WriteLine(e.EmpName);
            }
            return Content("Indexer demo executed. Check console output.");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
