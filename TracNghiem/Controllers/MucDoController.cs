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
    public class MucDoController : Controller
    {
        private readonly TracNghiemContext _context;

        public MucDoController(TracNghiemContext context)
        {
            _context = context;
        }

        // GET: MucDo
        public async Task<IActionResult> Index()
        {
            return View(await _context.MucDo.ToListAsync());
        }

        // GET: MucDo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mucDo = await _context.MucDo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mucDo == null)
            {
                return NotFound();
            }

            return View(mucDo);
        }

        // GET: MucDo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MucDo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenMucDo")] MucDo mucDo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mucDo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mucDo);
        }

        // GET: MucDo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mucDo = await _context.MucDo.FindAsync(id);
            if (mucDo == null)
            {
                return NotFound();
            }
            return View(mucDo);
        }

        // POST: MucDo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenMucDo")] MucDo mucDo)
        {
            if (id != mucDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mucDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MucDoExists(mucDo.Id))
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
            return View(mucDo);
        }

        // GET: MucDo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mucDo = await _context.MucDo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mucDo == null)
            {
                return NotFound();
            }

            return View(mucDo);
        }

        // POST: MucDo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mucDo = await _context.MucDo.FindAsync(id);
            if (mucDo != null)
            {
                _context.MucDo.Remove(mucDo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MucDoExists(int id)
        {
            return _context.MucDo.Any(e => e.Id == id);
        }
    }
}
