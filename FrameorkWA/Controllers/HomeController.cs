using FrameorkWA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;

namespace FrameorkWA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Instruções
        public IActionResult Index()
        {
            string caminhoDoPDF = "C:/Users/leona/Downloads/docFramework.pdf";

            // Verifica se o arquivo existe
            if (System.IO.File.Exists(caminhoDoPDF))
            {
                // Lê o arquivo PDF
                byte[] pdfBytes = System.IO.File.ReadAllBytes(caminhoDoPDF);

                // Converte o conteúdo para uma string base64 para ser incorporado em uma tag <embed>
                string base64 = System.Convert.ToBase64String(pdfBytes);
                string pdfDataUri = $"data:application/pdf;base64,{base64}";

                // Passa os dados para a visão
                ViewBag.PDFDataUri = pdfDataUri;

                // Retorna a visão
                return View();
            }
            else
            {
                // Se o arquivo não existir, redireciona para a página de erro
                return RedirectToAction("Error");
            }
    }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}