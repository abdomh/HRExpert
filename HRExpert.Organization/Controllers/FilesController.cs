using Microsoft.AspNetCore.Mvc;
using HRExpert.Organization.BL.Abstractions;
namespace HRExpert.Organization.Controllers
{
    /// <summary>
    /// Загрузка файлов
    /// </summary>
    [Route("/download/{fileid}")]
    public class FilesController: Controller
    {
        IFileBl filebl;
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="filebl"></param>
        public FilesController(IFileBl filebl)
        {
            this.filebl = filebl;
        }
        /// <summary>
        /// Получает файл по заданному одноразовому ключу
        /// </summary>
        /// <param name="fileid"></param>
        /// <returns></returns>
        [HttpGet]
        public FileResult Index(System.Guid fileid)
        {
            string fileName = "default";
            byte[] result = filebl.GetFile(fileid,out fileName);            
            return File(result, "application/x-msdownload", fileName);
        }
    }
}
