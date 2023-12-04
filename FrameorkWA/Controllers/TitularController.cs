using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrameorkWA.Data;
using FrameorkWA.Models;

namespace FrameorkWA.Controllers
{
    // Herda todos os métodos abstratos obrigatórios de MeuPaiAbstratoController
    public class TitularController : MeuPaiAbstratoController
    {
        private readonly FrameorkWAContext _context;

        public TitularController(FrameorkWAContext context)
        {
            _context = context;
        }

        // GET: Titular
        public override async Task<IActionResult> Index()
        {
            return View(await _context.Titular.ToListAsync());
        }

        //GET: Pais/MostrarFormularioDeBusca
        public override async Task<IActionResult> MostrarFormularioDeBuscaPai()
        {
            return View();
        }

        //POST: Titular/MostarResultadoDeBusca
        public override async Task<IActionResult> MostrarResultadoDeBuscaPai(string FraseDeBusca)
        {
            return View("Index",await _context.Titular.Where( p => p.Name.Contains(FraseDeBusca)).ToListAsync());
        }

        // GET: Titular/Details/5
        public override async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pai = await _context.Titular
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pai == null)
            {
                return NotFound();
            }

            return View(pai);
        }

        // GET: Titular/Create
        public override IActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([Bind("Id,Name,Email")] Titular pai)
        {
            _context.Add(pai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

         //   return View(pai);
        }

        // GET: Titular/Edit/5
        public override async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pai = await _context.Titular.FindAsync(id);
            if (pai == null)
            {
                return NotFound();
            }
            return View(pai);
        }

        // GET: Titular/Filhos/5
        public override async Task<IActionResult> Filhos(int id)
        {
            var pai = await _context.Titular
                .Include(s => s.Filhos)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pai == null)
            {
                return NotFound();
            }

            return View(pai.Filhos);
        }

        // POST: Titular/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email")] Titular pai)
        {
            if (id != pai.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(pai);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaiExists(pai.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            
        //    return View(pai);
        }


        // GET: Titular/Delete/5
        public override async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pai = await _context.Titular
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pai == null)
            {
                return NotFound();
            }

            return View(pai);
        }

        // POST: Titular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pai = await _context.Titular.FindAsync(id);
            if (pai != null)
            {
                _context.Titular.Remove(pai);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaiExists(int id)
        {
            return _context.Titular.Any(e => e.Id == id);
        }
    }
}
