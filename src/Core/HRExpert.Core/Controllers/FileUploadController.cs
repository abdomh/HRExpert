using System.Threading.Tasks;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
public class TestModel
{
    public IFormFile UserPic { get; set; }
    
    public IFormFile file { get; set; }
    public string UserName { get; set; }
}
[Route("/api/v1/fileupload")]
public class FileUploadController : Controller
{
    private IHostingEnvironment _environment;

    public FileUploadController(IHostingEnvironment environment)
    {
        _environment = environment;
    }
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(TestModel model)
    {
        var req = Request;
        var uploads = Path.Combine(_environment.WebRootPath, "uploads");
        List<IFormFile> files = new List<IFormFile>();
        files.Add(model.file);
        files.Add(model.UserPic);
        foreach (IFormFile file in files)
        {
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                
                return await Task.FromResult<IActionResult>(null);
            }
        }
        return View();
    }
}