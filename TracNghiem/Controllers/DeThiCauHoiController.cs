using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TracNghiem.Data;
using TracNghiem.Models;

namespace TracNghiem.Controllers
{
    public class DeThiCauHoiController : Controller
    {
        private readonly TracNghiemContext _context;

        public DeThiCauHoiController(TracNghiemContext context)
        {
            _context = context;
        }

        // GET: DeThiCauHoi
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeThiCauHoi.ToListAsync());
        }

        // GET: DeThiCauHoi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deThiCauHoi = await _context.DeThiCauHoi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deThiCauHoi == null)
            {
                return NotFound();
            }

            return View(deThiCauHoi);
        }

        // GET: DeThiCauHoi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeThiCauHoi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaDeThi,MaCauHoi")] DeThiCauHoi deThiCauHoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deThiCauHoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deThiCauHoi);
        }

        // GET: DeThiCauHoi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deThiCauHoi = await _context.DeThiCauHoi.FindAsync(id);
            if (deThiCauHoi == null)
            {
                return NotFound();
            }
            return View(deThiCauHoi);
        }

        // POST: DeThiCauHoi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaDeThi,MaCauHoi")] DeThiCauHoi deThiCauHoi)
        {
            if (id != deThiCauHoi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deThiCauHoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeThiCauHoiExists(deThiCauHoi.Id))
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
            return View(deThiCauHoi);
        }

        // GET: DeThiCauHoi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deThiCauHoi = await _context.DeThiCauHoi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deThiCauHoi == null)
            {
                return NotFound();
            }

            return View(deThiCauHoi);
        }

        // POST: DeThiCauHoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deThiCauHoi = await _context.DeThiCauHoi.FindAsync(id);
            if (deThiCauHoi != null)
            {
                _context.DeThiCauHoi.Remove(deThiCauHoi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeThiCauHoiExists(int id)
        {
            return _context.DeThiCauHoi.Any(e => e.Id == id);
        }
    }
}
