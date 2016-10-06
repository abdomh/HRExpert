using System;
using System.IO;
using Platformus.Barebone;
using Microsoft.AspNetCore.Http;
using HRExpert.Organization.DTO;
using HRExpert.Organization.Data.Models;
namespace HRExpert.Organization.BL
{
    public class BaseBL: Abstractions.IBaseBl
    {
        protected Abstractions.IMainService MainService;
        public BaseBL(Abstractions.IMainService mainService)
        {
            this.MainService = mainService;
        }     
        
        public DocumentFile SaveFile(IFormFile file, FileTypesEnum fileType )
        {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            var filename = Guid.NewGuid().ToString();
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            using (var fs = new FileStream(Path.Combine(dir, filename), FileMode.Create))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            return new DocumentFile() { FileName = file.FileName, Path=Path.Combine("uploads",filename), FileType = (int)fileType };
        }
        public byte[] GetFile(string Name)
        {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            byte[] result;
            using (var fs = new FileStream(Path.Combine(dir, Name), FileMode.Open))
            {
                result = ReadFull(fs);
            }
            return result;
        }
        private static byte[] ReadFull(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
