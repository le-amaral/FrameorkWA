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

        // Instru��es
        public IActionResult Index()
        {
            string caminhoDoPDF = "C:/Users/leona/Downloads/docFramework.pdf";

            // Verifica se o arquivo existe
            if (System.IO.File.Exists(caminhoDoPDF))
            {
                // L� o arquivo PDF
                byte[] pdfBytes = System.IO.File.ReadAllBytes(caminhoDoPDF);

                // Converte o conte�do para uma string base64 para ser incorporado em uma tag <embed>
                string base64 = System.Convert.ToBase64String(pdfBytes);
                string pdfDataUri = $"data:application/pdf;base64,{base64}";

                // Passa os dados para a vis�o
                ViewBag.PDFDataUri = pdfDataUri;

                // Retorna a vis�o
                return View();
            }
            else
            {
                // Se o arquivo n�o existir, redireciona para a p�gina de erro
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