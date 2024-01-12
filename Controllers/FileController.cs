using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AspNetMVC.Controllers
{
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DownloadFile(string firstName, string lastName, string fileName)
        {
            // Переконайтесь, що fileName містить розширення .txt
            if (!fileName.EndsWith(".txt"))
            {
                fileName += ".txt";
            }

            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "downloads", fileName);

            var fileContent = $"Ім'я: {firstName}{Environment.NewLine}Прізвище: {lastName}";

            await System.IO.File.WriteAllTextAsync(filePath, fileContent, Encoding.UTF8);

            return PhysicalFile(filePath, "text/plain", fileName);
        }

    }
}
