using System.Linq;
using System.Collections.Generic;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Core.Data.Models.Parent;
using HRExpert.Core.DTO;
namespace HRExpert.Core.BL
{
    public class ReferencyBl<T> : BaseBL, Abstractions.IReferencyBl where T : Referency, new()
    {
        #region Ctor
        public ReferencyBl(IStorage storage, IAuthService authService)
            :base(storage,authService)
        {
        }
        #endregion
        #region Private
        private IReferencyRepository<T> referencyRepository;
        #endregion
        #region Public
        public IReferencyRepository<T> ReferencyRepository { get { return referencyRepository; } }
        /// <summary>
        /// Repository setter
        /// </summary>
        /// <param name="repository"></param>
        public void SetRepository(IReferencyRepository<T> repository)
        {
            this.referencyRepository = repository;
        }
        #region CRUD
        public virtual IEnumerable<IdNameDto> List()
        {
            return ReferencyRepository.All().Select(x => ToDto(x));
        }
        public virtual IdNameDto Create(IdNameDto dto)
        {
            T entity = new T { Name = dto.Name };
            FromDto(entity, dto);
            ReferencyRepository.Create(entity);
            return ToDto(entity);
        }
        public virtual IdNameDto Read(long id)
        {
            return ToDto(ReferencyRepository.Read(id));
        }
        public virtual IdNameDto Update(IdNameDto dto)
        {
            T entity = ReferencyRepository.Read(dto.Id);
            this.FromDto(entity, dto);
            ReferencyRepository.Update(entity);
            return ToDto(entity);
        }
        public virtual IdNameDto Delete(long id)
        {
            var entity = ReferencyRepository.Read(id);
            entity.Delete = true;
            ReferencyRepository.Update(entity);
            return ToDto(entity);
        }
        #endregion 
        #region Converters
        public virtual IdNameDto ToDto(T entity)
        {
            IdNameDto result = new IdNameDto { Id = entity.Id, Name = entity.Name };
            return result;
        }
        public virtual void FromDto(T entity, IdNameDto dto)
        {
            entity.Name = dto.Name;
        }
        #endregion
        #endregion
        
    }
}
