using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FormApp.Data;
using FormApp.Models;

namespace FormApp.Controllers
{
    public class FormController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Form
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormModel.ToListAsync());
        }

        // GET: Form/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formModel = await _context.FormModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formModel == null)
            {
                return NotFound();
            }

            return View(formModel);
        }

        // GET: Form/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Form/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FormModel formModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formModel);
        }

        // GET: Form/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formModel = await _context.FormModel.FindAsync(id);
            if (formModel == null)
            {
                return NotFound();
            }
            return View(formModel);
        }

        // POST: Form/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] FormModel formModel)
        {
            if (id != formModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormModelExists(formModel.Id))
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
            return View(formModel);
        }

        // GET: Form/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formModel = await _context.FormModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formModel == null)
            {
                return NotFound();
            }

            return View(formModel);
        }

        // POST: Form/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formModel = await _context.FormModel.FindAsync(id);
            if (formModel != null)
            {
                _context.FormModel.Remove(formModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormModelExists(int id)
        {
            return _context.FormModel.Any(e => e.Id == id);
        }
    }
}
