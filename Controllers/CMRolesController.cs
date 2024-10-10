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
    public class CMRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CMRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CMRoles
        public async Task<IActionResult> Index()
        {
            var roles = await _context.CMRoles.OrderBy(x => x.RoleName).ToListAsync();
            return View(roles);
        }

        // GET: CMRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cMRole = await _context.CMRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cMRole == null)
            {
                return NotFound();
            }

            return View(cMRole);
        }

        // GET: CMRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CMRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoleName")] CMRole cMRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cMRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cMRole);
        }

        // GET: CMRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cMRole = await _context.CMRoles.FindAsync(id);
            if (cMRole == null)
            {
                return NotFound();
            }
            return View(cMRole);
        }

        // POST: CMRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoleName")] CMRole cMRole)
        {
            if (id != cMRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cMRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CMRoleExists(cMRole.Id))
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
            return View(cMRole);
        }

        // GET: CMRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cMRole = await _context.CMRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cMRole == null)
            {
                return NotFound();
            }

            return View(cMRole);
        }

        // POST: CMRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cMRole = await _context.CMRoles.FindAsync(id);
            if (cMRole != null)
            {
                _context.CMRoles.Remove(cMRole);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CMRoleExists(int id)
        {
            return _context.CMRoles.Any(e => e.Id == id);
        }
    }
}
