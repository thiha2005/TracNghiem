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
    public class ThanhVienController : Controller
    {
        private readonly TracNghiemContext _context;

        public ThanhVienController(TracNghiemContext context)
        {
            _context = context;
        }

        // GET: ThanhVien
        public async Task<IActionResult> Index()
        {
            return View(await _context.ThanhVien.ToListAsync());
        }

        // GET: ThanhVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhVien = await _context.ThanhVien
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thanhVien == null)
            {
                return NotFound();
            }

            return View(thanhVien);
        }

        // GET: ThanhVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThanhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenSinhVien,Sdt,Email,DiaChi,MatKhau,Lop,NgaySinh,GioiTinh,TaiKhoan,LaGiangVien")] ThanhVien thanhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thanhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thanhVien);
        }

        // GET: ThanhVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhVien = await _context.ThanhVien.FindAsync(id);
            if (thanhVien == null)
            {
                return NotFound();
            }
            return View(thanhVien);
        }

        // POST: ThanhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,TenSinhVien,Sdt,Email,DiaChi,MatKhau,Lop,NgaySinh,GioiTinh,TaiKhoan,LaGiangVien")] ThanhVien thanhVien)
        {
            if (id != thanhVien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thanhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThanhVienExists(thanhVien.Id))
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
            return View(thanhVien);
        }

        // GET: ThanhVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhVien = await _context.ThanhVien
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thanhVien == null)
            {
                return NotFound();
            }

            return View(thanhVien);
        }

        // POST: ThanhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var thanhVien = await _context.ThanhVien.FindAsync(id);
            if (thanhVien != null)
            {
                _context.ThanhVien.Remove(thanhVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThanhVienExists(string id)
        {
            return _context.ThanhVien.Any(e => e.Id == id);
        }
    }
}
