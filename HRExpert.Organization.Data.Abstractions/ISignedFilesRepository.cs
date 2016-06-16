using System;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    public interface ISignedFilesRepository: ExtCore.Data.Abstractions.IRepository
    {
        void Create(SignedFile entity);
        void Delete(SignedFile entity);
        void Delete(Guid Id);
        SignedFile Read(Guid Id);
    }
}