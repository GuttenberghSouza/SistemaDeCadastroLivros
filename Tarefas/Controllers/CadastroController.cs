using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarefas.Data;
using Tarefas.Models;

namespace Tarefas.Controllers
{
    public class CadastroController : Controller
    {
        private readonly Contexto _context;

        public CadastroController(Contexto context)
        {
            _context = context;
        }

        // GET: Cadastro
        public async Task<IActionResult> Index()
        {
              return View(await _context.cadastroModels.ToListAsync());
        }

        // GET: Cadastro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cadastroModels == null)
            {
                return NotFound();
            }

            var cadastroModel = await _context.cadastroModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroModel == null)
            {
                return NotFound();
            }

            return View(cadastroModel);
        }

        // GET: Cadastro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cadastro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Informacao,Autor,Ano")] CadastroModel cadastroModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroModel);
        }

        // GET: Cadastro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cadastroModels == null)
            {
                return NotFound();
            }

            var cadastroModel = await _context.cadastroModels.FindAsync(id);
            if (cadastroModel == null)
            {
                return NotFound();
            }
            return View(cadastroModel);
        }

        // POST: Cadastro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Informacao,Autor,Ano")] CadastroModel cadastroModel)
        {
            if (id != cadastroModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroModelExists(cadastroModel.Id))
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
            return View(cadastroModel);
        }

        // GET: Cadastro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cadastroModels == null)
            {
                return NotFound();
            }

            var cadastroModel = await _context.cadastroModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroModel == null)
            {
                return NotFound();
            }

            return View(cadastroModel);
        }

        // POST: Cadastro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cadastroModels == null)
            {
                return Problem("Entity set 'Contexto.cadastroModels'  is null.");
            }
            var cadastroModel = await _context.cadastroModels.FindAsync(id);
            if (cadastroModel != null)
            {
                _context.cadastroModels.Remove(cadastroModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroModelExists(int id)
        {
          return _context.cadastroModels.Any(e => e.Id == id);
        }
    }
}
