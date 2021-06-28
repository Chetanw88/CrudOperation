using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeMastersController : Controller
    {
        private readonly EmployeeMasterDBContext _context;

        public EmployeeMastersController(EmployeeMasterDBContext context)
        {
            _context = context;
        }

        // GET: EmployeeMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobLoadParams.ToListAsync());
        }

        // GET: EmployeeMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMaster = await _context.JobLoadParams
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeMaster == null)
            {
                return NotFound();
            }

            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,Email,PhoneNumber,Status")] EmployeeMaster employeeMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMaster = await _context.JobLoadParams.FindAsync(id);
            if (employeeMaster == null)
            {
                return NotFound();
            }
            return View(employeeMaster);
        }

        // POST: EmployeeMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName,Email,PhoneNumber,Status")] EmployeeMaster employeeMaster)
        {
            if (id != employeeMaster.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeMasterExists(employeeMaster.EmployeeId))
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
            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMaster = await _context.JobLoadParams
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeMaster == null)
            {
                return NotFound();
            }

            return View(employeeMaster);
        }

        // POST: EmployeeMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeMaster = await _context.JobLoadParams.FindAsync(id);
            _context.JobLoadParams.Remove(employeeMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeMasterExists(int id)
        {
            return _context.JobLoadParams.Any(e => e.EmployeeId == id);
        }
    }
}
