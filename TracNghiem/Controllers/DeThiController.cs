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
    public class DeThiController : Controller
    {
        private readonly TracNghiemContext _context;

        public DeThiController(TracNghiemContext context)
        {
            _context = context;
        }

        // GET: DeThi
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeThi.ToListAsync());
        }

        // GET: DeThi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deThi = await _context.DeThi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deThi == null)
            {
                return NotFound();
            }

            return View(deThi);
        }

        // GET: DeThi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeThi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NgayThi,ThoiGianThi,TenDeThi,SoLuongCauKho,SoLuongCauHoi")] DeThi deThi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deThi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deThi);
        }

        // GET: DeThi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deThi = await _context.DeThi.FindAsync(id);
            if (deThi == null)
            {
                return NotFound();
            }
            return View(deThi);
        }

        // POST: DeThi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NgayThi,ThoiGianThi,TenDeThi,SoLuongCauKho,SoLuongCauHoi")] DeThi deThi)
        {
            if (id != deThi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deThi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeThiExists(deThi.Id))
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
            return View(deThi);
        }

        // GET: DeThi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deThi = await _context.DeThi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deThi == null)
            {
                return NotFound();
            }

            return View(deThi);
        }

        // POST: DeThi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deThi = await _context.DeThi.FindAsync(id);
            if (deThi != null)
            {
                _context.DeThi.Remove(deThi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeThiExists(int id)
        {
            return _context.DeThi.Any(e => e.Id == id);
        }
    }
}
