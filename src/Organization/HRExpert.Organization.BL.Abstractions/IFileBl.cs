using System;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.BL.Abstractions
{
    public interface IFileBl
    {
        Guid CreateSign(DocumentFile file);
        byte[] GetFile(Guid key, out string filename);
    }
}