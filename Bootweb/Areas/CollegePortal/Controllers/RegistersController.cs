using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegePortal.Data;
using CollegePortal.Models;

namespace Bootweb.Areas.CollegePortal.Controllers
{
    [Area("CollegePortal")]
    public class RegistersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CollegePortal/Registers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Registers.Include(r => r.Dpt);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult Index2() {
            return View();

        }

        public IActionResult Contact()
        {
            return View();

        }
        // GET: CollegePortal/Registers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .Include(r => r.Dpt)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // GET: CollegePortal/Registers/Create
        public IActionResult Create()
        {
            ViewData["DptID"] = new SelectList(_context.Departments, "DptID", "DptName");
            return View();
        }

        // POST: CollegePortal/Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,StudentEmail,DptID")] Register register)
        {
            if (ModelState.IsValid)
            {
                _context.Add(register);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DptID"] = new SelectList(_context.Departments, "DptID", "DptName", register.DptID);
            return View(register);
        }

        // GET: CollegePortal/Registers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Registers.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }
            ViewData["DptID"] = new SelectList(_context.Departments, "DptID", "DptName", register.DptID);
            return View(register);
        }

        // POST: CollegePortal/Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,StudentEmail,DptID")] Register register)
        {
            if (id != register.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(register);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterExists(register.StudentId))
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
            ViewData["DptID"] = new SelectList(_context.Departments, "DptID", "DptName", register.DptID);
            return View(register);
        }

        // GET: CollegePortal/Registers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .Include(r => r.Dpt)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // POST: CollegePortal/Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var register = await _context.Registers.FindAsync(id);
            _context.Registers.Remove(register);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterExists(int id)
        {
            return _context.Registers.Any(e => e.StudentId == id);
        }
    }
}
