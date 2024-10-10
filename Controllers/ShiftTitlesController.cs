using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WDWShiftX.Data;
using WDWShiftX.Models;

namespace WDWShiftX.Controllers
{
    public class ShiftTitlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShiftTitlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShiftTitles
        public async Task<IActionResult> Index()
        {
            var shiftTitles = await _context.ShiftTitles
                    .Include(st => st.CMRole) // Include the CMRole entity
                    .Include(st => st.Property) // Include the Property entity
                    .OrderBy(x => x.ShiftName)
                    .ToListAsync();

            return View(shiftTitles);
        }

        // GET: ShiftTitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftTitle = await _context.ShiftTitles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shiftTitle == null)
            {
                return NotFound();
            }

            return View(shiftTitle);
        }

        // GET: ShiftTitles/Create
        public async Task<IActionResult> Create()
        {
            // Populate the view with data for the dropdowns
            ViewBag.CMRoleId = new SelectList(_context.CMRoles, "Id", "RoleName");
            ViewBag.PropertyId = new SelectList(_context.Properties, "Id", "PropertyName");
            return View();
        }

        // POST: ShiftTitles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShiftName,CMRoleId,PropertyId")] ShiftTitle shiftTitle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shiftTitle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Populate the view with data for the dropdowns (in case of validation errors)
            ViewBag.CMRoleId = new SelectList(_context.CMRoles, "Id", "RoleName");
            ViewBag.PropertyId = new SelectList(_context.Properties, "Id", "PropertyName");
            return View(shiftTitle);
        }

        // GET: ShiftTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftName = await _context.ShiftTitles
                .Include(st => st.CMRole) // Include CMRole for name lookup
                .Include(st => st.Property) // Include Property for name lookup
                .FirstOrDefaultAsync(m => m.Id == id);

            if (shiftName == null)
            {
                return NotFound();
            }

            // Populate the view with data for the dropdowns
            ViewBag.CMRoles = new SelectList(_context.CMRoles, "Id", "RoleName", shiftName.CMRoleId);
            ViewBag.Properties = new SelectList(_context.Properties, "Id", "PropertyName", shiftName.PropertyId);

            return View(shiftName);
        }

        // POST: ShiftTitles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,CMRoleId,PropertyId")] ShiftTitle shiftTitle)
        {
            if (id != shiftTitle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shiftTitle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShiftTitleExists(shiftTitle.Id))
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
            return View(shiftTitle);
        }

        // GET: ShiftTitles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftTitle = await _context.ShiftTitles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shiftTitle == null)
            {
                return NotFound();
            }

            return View(shiftTitle);
        }

        // POST: ShiftTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shiftTitle = await _context.ShiftTitles.FindAsync(id);
            if (shiftTitle != null)
            {
                _context.ShiftTitles.Remove(shiftTitle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShiftTitleExists(int id)
        {
            return _context.ShiftTitles.Any(e => e.Id == id);
        }
    }
}
