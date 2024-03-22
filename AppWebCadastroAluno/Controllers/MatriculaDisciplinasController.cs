using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppWebCadastroAluno.DAL;
using AppWebCadastroAluno.Models;

namespace AppWebCadastroAluno.Controllers
{
    public class MatriculaDisciplinasController : Controller
    {
        private readonly INFNETContexto _context;

        public MatriculaDisciplinasController(INFNETContexto context)
        {
            _context = context;
        }
        // GET: MatriculaDisciplinas
        public async Task<IActionResult> Index()
        {
            var iNFNETContexto = _context.MatriculaDisciplina
                .Include(m => m.Disciplina)
                .Include(m => m.Matricula).ThenInclude(ma => ma.Aluno)
                .Include(md => md.Matricula.Curso)
                .Include(me => me.Matricula.Aluno.Endereco);


            return View(await iNFNETContexto.ToListAsync());
        }

        

        // GET: MatriculaDisciplinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matriculaDisciplina = await _context.MatriculaDisciplina
                .Include(m => m.Disciplina)
                .Include(m => m.Matricula)
                .FirstOrDefaultAsync(m => m.MatriculaDsciplinaId == id);
            if (matriculaDisciplina == null)
            {
                return NotFound();
            }

            return View(matriculaDisciplina);
        }

        // GET: MatriculaDisciplinas/Create
        public IActionResult Create()
        {
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "DisciplinaId", "Nome");
            //ViewData["MatriculaId"] = new SelectList(_context.Matriculas, "MatriculaId", "MatriculaId");
            var alunos = _context.Alunos.ToList();
            ViewData["AlunoId"] = new SelectList(alunos, "AlunoId", "Nome");
            return View();
        }

        // POST: MatriculaDisciplinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatriculaDsciplinaId,DisciplinaId,MatriculaId")] MatriculaDisciplina matriculaDisciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matriculaDisciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "DisciplinaId", "Nome", matriculaDisciplina.DisciplinaId);
            ViewData["MatriculaId"] = new SelectList(_context.Matriculas, "MatriculaId", "MatriculaId", matriculaDisciplina.MatriculaId);
            return View(matriculaDisciplina);
        }

        // GET: MatriculaDisciplinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matriculaDisciplina = await _context.MatriculaDisciplina.FindAsync(id);
            if (matriculaDisciplina == null)
            {
                return NotFound();
            }
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "DisciplinaId", "Nome", matriculaDisciplina.DisciplinaId);
            ViewData["MatriculaId"] = new SelectList(_context.Matriculas, "MatriculaId", "MatriculaId", matriculaDisciplina.MatriculaId);
            return View(matriculaDisciplina);
        }

        // POST: MatriculaDisciplinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MatriculaDsciplinaId,DisciplinaId,MatriculaId")] MatriculaDisciplina matriculaDisciplina)
        {
            if (id != matriculaDisciplina.MatriculaDsciplinaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matriculaDisciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaDisciplinaExists(matriculaDisciplina.MatriculaDsciplinaId))
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
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "DisciplinaId", "Nome", matriculaDisciplina.DisciplinaId);
            ViewData["MatriculaId"] = new SelectList(_context.Matriculas, "MatriculaId", "MatriculaId", matriculaDisciplina.MatriculaId);
            return View(matriculaDisciplina);
        }

        // GET: MatriculaDisciplinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matriculaDisciplina = await _context.MatriculaDisciplina
                .Include(m => m.Disciplina)
                .Include(m => m.Matricula)
                .FirstOrDefaultAsync(m => m.MatriculaDsciplinaId == id);
            if (matriculaDisciplina == null)
            {
                return NotFound();
            }

            return View(matriculaDisciplina);
        }

        // POST: MatriculaDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matriculaDisciplina = await _context.MatriculaDisciplina.FindAsync(id);
            if (matriculaDisciplina != null)
            {
                _context.MatriculaDisciplina.Remove(matriculaDisciplina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaDisciplinaExists(int id)
        {
            return _context.MatriculaDisciplina.Any(e => e.MatriculaDsciplinaId == id);
        }
    }
}
