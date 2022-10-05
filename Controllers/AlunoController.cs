using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc.Context;
using mvc.Models;
namespace mvc.Controllers
{
    public class AlunoController : Controller
    {
        private readonly ListaContext _context;
        public AlunoController(ListaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var alunos = _context.Alunos.ToList();
            return View(alunos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Alunos.Add(aluno);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }
        public IActionResult Editar(int id)
        {
             var aluno = _context.Alunos.Find(id);
            if (aluno == null)
            {
                return NotFound();    
            }
            return View(aluno);
        }   
        [HttpPost]
        public IActionResult Editar(Aluno aluno)
        {
            var alunoEditado = _context.Alunos.Find(aluno.Id);
            
            alunoEditado.Nome = aluno.Nome;
            alunoEditado.Turma = aluno.Turma;
            alunoEditado.Livro = aluno.Livro;
            _context.Alunos.Update(alunoEditado);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Recebido (int id)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null)
            {
                return RedirectToAction(nameof(Index));                
            }
            return View(aluno);
        }
        [HttpPost]
        public IActionResult Recebido (Aluno aluno)
        {
            var alunoConcluido = _context.Alunos.Find(aluno.Id);
            _context.Alunos.Remove(alunoConcluido);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }

}