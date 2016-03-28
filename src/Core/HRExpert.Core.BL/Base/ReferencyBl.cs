using System.Linq;
using System.Collections.Generic;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Core.Abstractions;
using HRExpert.Core.Data.Models.Parent;

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
        public virtual IEnumerable<IIdName> List()
        {
            return ReferencyRepository.All().Select(x => x.ToDto());
        }
        public virtual void Create(IIdName dto)
        {
            T entity = new T { Name = dto.Name };
            ReferencyRepository.Create(entity);
            dto = entity.ToDto();
        }
        public virtual IIdName Read(long id)
        {
            return ReferencyRepository.Read(id).ToDto();
        }
        public virtual void Update(IIdName dto)
        {
            T entity = ReferencyRepository.Read(dto.Id);            
            ReferencyRepository.Update(entity.FromDto(dto));            
        }       
    }
}
