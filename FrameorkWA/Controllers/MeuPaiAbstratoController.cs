using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FrameorkWA.Data;
using FrameorkWA.Models;

namespace FrameorkWA.Controllers
{
    public abstract class MeuPaiAbstratoController : Controller
    {
        // Método inicial
        public abstract Task<IActionResult> Index();

        // Métodos de busca
        public abstract Task<IActionResult> MostrarFormularioDeBuscaPai();
        public abstract Task<IActionResult> MostrarResultadoDeBuscaPai(string FraseDeBusca);

        // Métodos de cadastro simples(Pai)
        // CRUD
        public abstract Task<IActionResult> Details(int? id);
        public abstract IActionResult Create();
        public abstract Task<IActionResult> Create([Bind("Id,Name,Email")] Titular pai);
        public abstract Task<IActionResult> Edit(int? id);
        public abstract Task<IActionResult> Filhos(int id);
        public abstract Task<IActionResult> Edit(int id, [Bind("Id,Name,Email")] Titular pai);
        public abstract Task<IActionResult> Delete(int? id);
        public abstract Task<IActionResult> DeleteConfirmed(int id);

    }
}
