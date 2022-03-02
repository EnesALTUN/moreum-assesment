using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDocumentGeneratorService _documentService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(ILogger<HomeController> logger, IDocumentGeneratorService documentService, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _documentService = documentService;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateDocument(InvoiceTempateFormDto files)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = await _documentService.CreateInvoiceTemplateAsync(_hostEnvironment.WebRootPath, files);

                if (isSuccess)
                    TempData["Success"] = "İşlem Başarılı";
                else
                    TempData["Error"] = "İşlem Başarısız";
            }

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}