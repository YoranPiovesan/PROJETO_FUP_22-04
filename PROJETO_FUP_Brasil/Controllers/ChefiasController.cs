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
    public class ChefiasController : Controller
    {
        private readonly PROJETO_FUP_BrasilContext _context;

        public ChefiasController(PROJETO_FUP_BrasilContext context)
        {
            _context = context;
        }

        // GET: Chefias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chefia.ToListAsync());
        }

        // GET: Chefias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chefia = await _context.Chefia
                .FirstOrDefaultAsync(m => m.Id_Chefia == id);
            if (chefia == null)
            {
                return NotFound();
            }

            return View(chefia);
        }

        // GET: Chefias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chefias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Chefia,Nome,Cpf,Rg,Setor")] Chefia chefia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chefia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chefia);
        }

        // GET: Chefias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chefia = await _context.Chefia.FindAsync(id);
            if (chefia == null)
            {
                return NotFound();
            }
            return View(chefia);
        }

        // POST: Chefias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Chefia,Nome,Cpf,Rg,Setor")] Chefia chefia)
        {
            if (id != chefia.Id_Chefia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chefia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChefiaExists(chefia.Id_Chefia))
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
            return View(chefia);
        }

        // GET: Chefias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chefia = await _context.Chefia
                .FirstOrDefaultAsync(m => m.Id_Chefia == id);
            if (chefia == null)
            {
                return NotFound();
            }

            return View(chefia);
        }

        // POST: Chefias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chefia = await _context.Chefia.FindAsync(id);
            _context.Chefia.Remove(chefia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChefiaExists(int id)
        {
            return _context.Chefia.Any(e => e.Id_Chefia == id);
        }
    }
}
