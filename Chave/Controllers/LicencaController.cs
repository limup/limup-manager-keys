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
    public class LicencaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LicencaController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Licenca
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Licenca.Include(l => l.Empresa);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Licenca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licencaViewModels = await _context.Licenca
                .Include(l => l.Empresa)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (licencaViewModels == null)
            {
                return NotFound();
            }

            return View(licencaViewModels);
        }

        // GET: Licenca/Create
        public IActionResult Create()
        {
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "Id", "Nome");
            return View();
        }

        // POST: Licenca/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEmpresa,Chave,Dispositivo,Plataforma,DataLicenca")] LicencaViewModels licencaViewModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(licencaViewModels);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "Id", "Nome", licencaViewModels.IdEmpresa);
            return View(licencaViewModels);
        }

        // GET: Licenca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licencaViewModels = await _context.Licenca.SingleOrDefaultAsync(m => m.Id == id);
            if (licencaViewModels == null)
            {
                return NotFound();
            }
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "Id", "Nome", licencaViewModels.IdEmpresa);
            return View(licencaViewModels);
        }

        // POST: Licenca/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdEmpresa,Chave,Dispositivo,Plataforma,DataLicenca")] LicencaViewModels licencaViewModels)
        {
            if (id != licencaViewModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(licencaViewModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicencaViewModelsExists(licencaViewModels.Id))
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
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "Id", "Nome", licencaViewModels.IdEmpresa);
            return View(licencaViewModels);
        }

        // GET: Licenca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licencaViewModels = await _context.Licenca
                .Include(l => l.Empresa)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (licencaViewModels == null)
            {
                return NotFound();
            }

            return View(licencaViewModels);
        }

        // POST: Licenca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var licencaViewModels = await _context.Licenca.SingleOrDefaultAsync(m => m.Id == id);
            _context.Licenca.Remove(licencaViewModels);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LicencaViewModelsExists(int id)
        {
            return _context.Licenca.Any(e => e.Id == id);
        }
    }
}
