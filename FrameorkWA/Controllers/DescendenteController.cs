using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrameorkWA.Data;
using FrameorkWA.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace FrameorkWA.Controllers
{
    // Herda todos os métodos abstratos obrigatórios de MeuFilhoAbstratoController
    public class DescendenteController : MeuFilhoAbstratoController
    {
        private readonly FrameorkWAContext _context;

        public DescendenteController(FrameorkWAContext context)
        {
            _context = context;
        }

        // GET: Filhoes
        public override async Task<IActionResult> Index()
        {
            List<Descendentes> Filhos = await (from f in _context.Descendentes
                join x in _context.Titular on f.PaiId equals x.Id into _p
                from p in _p.DefaultIfEmpty()
                select new Descendentes{
                    Id = f.Id,
                    Name = f.Name,
                    PaiId = f.PaiId,
                    Email = f.Email,
                    Pai = p
                }).ToListAsync();
            return View(Filhos);
        }

        //GET: Filhos/MostrarFormularioDeBusca
        public override async Task<IActionResult> MostrarFormularioDeBuscaFilho()
        {
            return View();
        }

        public override async Task<IActionResult> MostrarFormularioDeBuscaPaiFilho()
        {
            return View();
        }
        //POST: Filhos/MostarResultadoDeBusca
        public override async Task<IActionResult> MostrarResultadoDeBuscaFilho(string FraseDeBusca)
        {
            return View("Index", await _context.Descendentes.Where(p => p.Name.Contains(FraseDeBusca)).ToListAsync());
        }

        public override async Task<IActionResult> MostrarResultadoDeBuscaPaiFilho(string FraseDeBusca)
        {
            int idPai = int.Parse(FraseDeBusca);
            List<Descendentes> Filhos = await (from f in _context.Descendentes
                join x in _context.Titular on f.PaiId equals x.Id into _p
                from p in _p.DefaultIfEmpty()
                where f.PaiId == idPai
                select new Descendentes{
                    Id = f.Id,
                    Name = f.Name,
                    PaiId = f.PaiId,
                    Email = f.Email,
                    Pai = p
                }).ToListAsync();
            return View("Index", Filhos);
        }
        // GET: Filhoes/Details/5
        public override async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filho = await _context.Descendentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filho == null)
            {
                return NotFound();
            }

            return View(filho);
        }

        // GET: Filhoes/Create
        public override IActionResult Create()
        {
            return View();
        }

        // POST: Filhoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([Bind("Id,Name,PaiId, Email,Pai")] Descendentes filho)
        {

            _context.Add(filho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //return View(filho);
        }

        // GET: Filhoes/Edit/5
        public override async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filho = await _context.Descendentes.FindAsync(id);
            if (filho == null)
            {
                return NotFound();
            }
            return View(filho);
        }

        // POST: Filhoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Edit(int id, [Bind("Id,Name,PaiId,Email,Pai")] Descendentes filho)
        {
            if (id != filho.Id)
            {
                return NotFound();
            }
            
            try
            {
                _context.Update(filho);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilhoExists(filho.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            //return View(filho);
        }

        // GET: Filhoes/Delete/5
        public override async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filho = await _context.Descendentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filho == null)
            {
                return NotFound();
            }

            return View(filho);
        }

        // POST: Filhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filho = await _context.Descendentes.FindAsync(id);
            if (filho != null)
            {
                _context.Descendentes.Remove(filho);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilhoExists(int id)
        {
            return _context.Descendentes.Any(e => e.Id == id);
        }
    }
}
