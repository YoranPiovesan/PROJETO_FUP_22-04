using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROJETO_FUP_Brasil.Data;
using PROJETO_FUP_Brasil.Models;
using Remake_FUP.Models;

namespace PROJETO_FUP_Brasil.Controllers
{
    public class AlunosController : Controller
    {
        private readonly PROJETO_FUP_BrasilContext _context;

        public AlunosController(PROJETO_FUP_BrasilContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aluno.ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.Id_Matricula == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        [HttpGet]
        [Authorize(Policy = "Admins")]
        public IActionResult Create()
        {
                PopulateCursosDropDownList();
                return View();
        }


        private void PopulateCursosDropDownList(object selectedCursos = null)
        {
            var cursosQuery = from d in _context.Cursos
                              orderby d.Id_Curso
                              select d;
            ViewBag.bla = new SelectList(cursosQuery.AsNoTracking(),"NomeCurso", "NomeCurso", selectedCursos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeCurso","NomeCurso")] Cursos cursos, Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateCursosDropDownList(cursos.Id_Curso);
            return View(aluno);
        }

    

        // GET: Alunos/Edit/5
        [Authorize(Policy = "Admins")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            PopulateCursosDropDownList();
            
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admins")]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Matricula,Nome,Rg,Cpf,Datanascimento,Genero,Curso")] Aluno aluno)
        {
            if (id != aluno.Id_Matricula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.Id_Matricula))
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
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        [Authorize(Policy = "Admins")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.Id_Matricula == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admins")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Aluno.Any(e => e.Id_Matricula == id);
        }
    }
}
