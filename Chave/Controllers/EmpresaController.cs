using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chave.Data;
using Chave.Models.ChaveViewModels;

namespace Chave.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpresaController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Empresa
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empresa.ToListAsync());
        }

        // GET: Empresa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaViewModels = await _context.Empresa
                .SingleOrDefaultAsync(m => m.Id == id);
            if (empresaViewModels == null)
            {
                return NotFound();
            }

            return View(empresaViewModels);
        }

        // GET: Empresa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empresa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] EmpresaViewModels empresaViewModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresaViewModels);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(empresaViewModels);
        }

        // GET: Empresa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaViewModels = await _context.Empresa.SingleOrDefaultAsync(m => m.Id == id);
            if (empresaViewModels == null)
            {
                return NotFound();
            }
            return View(empresaViewModels);
        }

        // POST: Empresa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] EmpresaViewModels empresaViewModels)
        {
            if (id != empresaViewModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresaViewModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaViewModelsExists(empresaViewModels.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(empresaViewModels);
        }

        // GET: Empresa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaViewModels = await _context.Empresa
                .SingleOrDefaultAsync(m => m.Id == id);
            if (empresaViewModels == null)
            {
                return NotFound();
            }

            return View(empresaViewModels);
        }

        // POST: Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresaViewModels = await _context.Empresa.SingleOrDefaultAsync(m => m.Id == id);
            _context.Empresa.Remove(empresaViewModels);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmpresaViewModelsExists(int id)
        {
            return _context.Empresa.Any(e => e.Id == id);
        }
    }
}
