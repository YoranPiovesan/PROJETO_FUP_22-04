using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROJETO_FUP_Brasil.Data;
using Remake_FUP.Models;

namespace PROJETO_FUP_Brasil.Controllers
{
    public class FinanceiroController : Controller
    {
        private readonly PROJETO_FUP_BrasilContext _context;

        public FinanceiroController(PROJETO_FUP_BrasilContext context)
        {
            _context = context;
        }

        // GET: Financeiro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Financeiro.ToListAsync());
        }

        // GET: Financeiro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financeiro
                .FirstOrDefaultAsync(m => m.Id_Financeiro == id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return View(financeiro);
        }

        // GET: Financeiro/Create
        public IActionResult Create()
        {
            PopulateFinanceiroDropDownList();
            return View();
        }
        private void PopulateFinanceiroDropDownList(object selectedAluno = null)
        {
            var alunoQuery = from f in _context.Aluno
                              orderby f.Id_Matricula
                              select f;
            ViewBag.Financa = new SelectList(alunoQuery.AsNoTracking(), "Nome", "Nome" , selectedAluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Financeiro,Direcao_Financeira,Descricao_Financeira,Valor, Aluno")] Financeiro financeiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(financeiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateFinanceiroDropDownList();
            return View(financeiro);
        }

        // GET: Financeiro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financeiro.FindAsync(id);
            if (financeiro == null)
            {
                return NotFound();
            }
            return View(financeiro);
        }

        // POST: Financeiro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Financeiro,Direcao_Financeira,Descricao_Financeira,Valor")] Financeiro financeiro)
        {
            if (id != financeiro.Id_Financeiro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(financeiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinanceiroExists(financeiro.Id_Financeiro))
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
            return View(financeiro);
        }

        // GET: Financeiro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financeiro
                .FirstOrDefaultAsync(m => m.Id_Financeiro == id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return View(financeiro);
        }

        // POST: Financeiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var financeiro = await _context.Financeiro.FindAsync(id);
            _context.Financeiro.Remove(financeiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinanceiroExists(int id)
        {
            return _context.Financeiro.Any(e => e.Id_Financeiro == id);
        }
    }
}
