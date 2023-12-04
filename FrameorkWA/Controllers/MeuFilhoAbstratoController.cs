using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FrameorkWA.Data;
using FrameorkWA.Models;

namespace FrameorkWA.Controllers
{
    public abstract class MeuFilhoAbstratoController : Controller
    {
        // Método inicial
        public abstract Task<IActionResult> Index();
        // Métodos de busca
        public abstract Task<IActionResult> MostrarFormularioDeBuscaFilho();
        public abstract Task<IActionResult> MostrarFormularioDeBuscaPaiFilho();
        public abstract Task<IActionResult> MostrarResultadoDeBuscaFilho(string FraseDeBusca);

        public abstract Task<IActionResult> MostrarResultadoDeBuscaPaiFilho(string FraseDeBusca);
        // Métodos de cadastro filho
        // CRUD
        public abstract Task<IActionResult> Details(int? id);
        public abstract IActionResult Create();
        public abstract Task<IActionResult> Create([Bind("Id,Name,PaiId,Email")] Descendentes filho);
        public abstract Task<IActionResult> Edit(int? id);
        public abstract Task<IActionResult> Edit(int id, [Bind("Id,Name,PaiId,Email")] Descendentes filho);
        public abstract Task<IActionResult> Delete(int? id);
        public abstract Task<IActionResult> DeleteConfirmed(int id);
    }
}
