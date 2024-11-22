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
    public class CauHoiController : Controller
    {
        private readonly TracNghiemContext _context;

        public CauHoiController(TracNghiemContext context)
        {
            _context = context;
        }

        // GET: CauHoi
        public async Task<IActionResult> Index()
        {
            return View(await _context.CauHoi.ToListAsync());
        }

        // GET: CauHoi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cauHoi = await _context.CauHoi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cauHoi == null)
            {
                return NotFound();
            }

            return View(cauHoi);
        }

        // GET: CauHoi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CauHoi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CauHoi1,DapAnA,DapAnB,DapAnC,DapAnD,DapAn,GhiChu,MaMonHoc,MaMucDo")] CauHoi cauHoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cauHoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cauHoi);
        }

        // GET: CauHoi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cauHoi = await _context.CauHoi.FindAsync(id);
            if (cauHoi == null)
            {
                return NotFound();
            }
            return View(cauHoi);
        }

        // POST: CauHoi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CauHoi1,DapAnA,DapAnB,DapAnC,DapAnD,DapAn,GhiChu,MaMonHoc,MaMucDo")] CauHoi cauHoi)
        {
            if (id != cauHoi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cauHoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CauHoiExists(cauHoi.Id))
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
            return View(cauHoi);
        }

        // GET: CauHoi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cauHoi = await _context.CauHoi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cauHoi == null)
            {
                return NotFound();
            }

            return View(cauHoi);
        }

        // POST: CauHoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cauHoi = await _context.CauHoi.FindAsync(id);
            if (cauHoi != null)
            {
                _context.CauHoi.Remove(cauHoi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CauHoiExists(int id)
        {
            return _context.CauHoi.Any(e => e.Id == id);
        }
    }
}
