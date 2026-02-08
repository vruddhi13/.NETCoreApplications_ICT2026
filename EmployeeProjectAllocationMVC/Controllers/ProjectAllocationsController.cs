using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeProjectAllocationMVC.Models;

namespace EmployeeProjectAllocationMVC.Controllers
{
    public class ProjectAllocationsController : Controller
    {
        private readonly ProjectAllocationDB _context;

        public ProjectAllocationsController(ProjectAllocationDB context)
        {
            _context = context;
        }

        // GET: ProjectAllocations
        public async Task<IActionResult> Index(String SearchProject)
        {
            var projectAllocationDB = _context.ProjectAllocations.Include(p => p.Emp).Include(p => p.Pro).AsQueryable();

            if (!String.IsNullOrEmpty(SearchProject))
            {
                projectAllocationDB = projectAllocationDB.Where(x => x.Pro.ProName.Contains(SearchProject));

            }
            return View(await projectAllocationDB.ToListAsync());
        }

        // GET: ProjectAllocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectAllocation = await _context.ProjectAllocations
                .Include(p => p.Emp)
                .FirstOrDefaultAsync(m => m.ProAllocateId == id);
            if (projectAllocation == null)
            {
                return NotFound();
            }

            return View(projectAllocation);
        }

        // GET: ProjectAllocations/Create
        public IActionResult Create()
        {
            ViewData["EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpName");
            ViewData["ProId"] = new SelectList(_context.Projects, "ProId", "ProName");
            return View();
        }

        // POST: ProjectAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProAllocateId,EmpId,ProId,AllocationDate")] ProjectAllocation projectAllocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectAllocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpName", projectAllocation.EmpId);
            ViewData["ProId"] = new SelectList(_context.Projects, "ProId", "ProName", projectAllocation.ProId);
            return View(projectAllocation);
        }

        // GET: ProjectAllocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectAllocation = await _context.ProjectAllocations.FindAsync(id);
            if (projectAllocation == null)
            {
                return NotFound();
            }
            ViewData["EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpId", projectAllocation.EmpId);
            ViewData["ProId"] = new SelectList(_context.Projects, "ProId", "ProName", projectAllocation.ProId);
            return View(projectAllocation);
        }

        // POST: ProjectAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProAllocateId,EmpId,ProId,AllocationDate")] ProjectAllocation projectAllocation)
        {
            if (id != projectAllocation.ProAllocateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectAllocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectAllocationExists(projectAllocation.ProAllocateId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpId", projectAllocation.EmpId);
            ViewData["ProId"] = new SelectList(_context.Projects, "ProId", "ProName", projectAllocation.ProId);
            return View(projectAllocation);
        }

        // GET: ProjectAllocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectAllocation = await _context.ProjectAllocations
                .Include(p => p.Emp)
                .FirstOrDefaultAsync(m => m.ProAllocateId == id);
            if (projectAllocation == null)
            {
                return NotFound();
            }

            return View(projectAllocation);
        }

        // POST: ProjectAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectAllocation = await _context.ProjectAllocations.FindAsync(id);
            if (projectAllocation != null)
            {
                _context.ProjectAllocations.Remove(projectAllocation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectAllocationExists(int id)
        {
            return _context.ProjectAllocations.Any(e => e.ProAllocateId == id);
        }
    }
}
