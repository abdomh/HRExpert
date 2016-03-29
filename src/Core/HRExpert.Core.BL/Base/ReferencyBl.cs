using System.Linq;
using System.Collections.Generic;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Core.Abstractions;
using HRExpert.Core.Data.Models.Parent;
using HRExpert.Core.DTO;
namespace HRExpert.Core.BL
{
    public class ReferencyBl<T> : Abstractions.IReferencyBl where T : Referency, new()
    {
        #region Private
        private IReferencyRepository<T> referencyRepository;
        #endregion
        #region Public
        IReferencyRepository<T> ReferencyRepository { get { return referencyRepository; } }
        #endregion
        public void SetRepository(IReferencyRepository<T> repository)
        {
            this.referencyRepository = repository;
        }
        public virtual IEnumerable<IdNameDto> List()
        {
            return ReferencyRepository.All().Select(x => x.ToDto());
        }
        public virtual void Create(IdNameDto dto)
        {
            T entity = new T { Name = dto.Name };
            ReferencyRepository.Create(entity);
            dto = entity.ToDto();
        }
        public virtual IdNameDto Read(long id)
        {
            return ReferencyRepository.Read(id).ToDto();
        }
        public virtual void Update(IdNameDto dto)
        {
            T entity = ReferencyRepository.Read(dto.Id);            
            ReferencyRepository.Update(entity.FromDto(dto));            
        }       
    }
}
