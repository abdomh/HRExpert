using System;
using System.IO;
using HRExpert.Organization.Data.Models;
using HRExpert.Core.Services.Abstractions;
using ExtCore.Data.Abstractions;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Organization.DTO;
using System.Collections.Generic;
using System.Linq;

namespace HRExpert.Organization.BL
{
    public class FileBl: Abstractions.IFileBl
    {
        ISignedFilesRepository filesRepository;
        IAuthService authService;
        public FileBl(IStorage storage, IAuthService authService)
        {
            this.filesRepository = storage.GetRepository<ISignedFilesRepository>();
            this.authService = authService;
        }
        public Guid CreateSign(DocumentFile file)
        {            
            SignedFile result = new SignedFile() { File = file };
            filesRepository.Create(result);
            return result.Id;
        }
        public byte[] GetFile(Guid key, out string filename)
        {
            var file = filesRepository.Read(key);
            filename = file.File.FileName;
            string path = Path.Combine(authService.RootPath, file.File.Path) ;
            var result = File.ReadAllBytes(path);
            if (file.DeleteAfterDownload) filesRepository.Delete(key);
            return result;            
        }
    }
}
