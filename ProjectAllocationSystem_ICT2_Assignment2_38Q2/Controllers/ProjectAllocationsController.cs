using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectAllocationSystem_ICT2_Assignment2_38Q2.Models;
using ProjectAllocationSystem_ICT2_Assignment2_38Q2.ViewModel;

namespace ProjectAllocationSystem_ICT2_Assignment2_38Q2.Controllers
{
    public class ProjectAllocationsController : Controller
    {
        private readonly ProjectAllocationDbContext _context;

        public ProjectAllocationsController(ProjectAllocationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectAllocations
        public async Task<IActionResult> Index(string SearchProject)
        {
            var projectAllocationDbContext = _context.ProjectAllocations.Include(p => p.Emp).Include(p => p.Project).AsQueryable();

            if (!String.IsNullOrEmpty(SearchProject))
            {
                projectAllocationDbContext = projectAllocationDbContext.Where(x => x.Project.ProjectName.Contains(SearchProject));

            }
            return View(await projectAllocationDbContext.ToListAsync());
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
                .Include(p => p.Project)
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName");
            return View();
        }

        // POST: ProjectAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProAllocateId,EmpId,ProjectId,AllocatedDate")] ProjectAllocation projectAllocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectAllocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpName", projectAllocation.EmpId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName", projectAllocation.ProjectId);
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
            ViewData["EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpName", projectAllocation.EmpId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName", projectAllocation.ProjectId);
            return View(projectAllocation);
        }

        // POST: ProjectAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProAllocateId,EmpId,ProjectId,AllocatedDate")] ProjectAllocation projectAllocation)
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", projectAllocation.ProjectId);
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
                .Include(p => p.Project)
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
