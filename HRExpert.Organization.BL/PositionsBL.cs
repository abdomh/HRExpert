using System.Linq;
using System.Collections.Generic;
using HRExpert.Organization.Data.Models;
using HRExpert.Core.Services.Abstractions;
using ExtCore.Data.Abstractions;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Organization.DTO;
namespace HRExpert.Organization.BL
{
    public class PositionsBL: Abstractions.IPositionsBL
    {
        private IPositionRepository positionRepository;
        private IAuthService authService;
        public PositionsBL(IStorage storage, IAuthService authService)        
        {
            this.positionRepository = storage.GetRepository<IPositionRepository>();
            this.authService = authService;
        }
        #region CRUD
        public virtual IEnumerable<PositionDto> List()
        {
            return this.positionRepository.All().Select(x => ToDto(x));
        }
        public virtual PositionDto Create(PositionDto dto)
        {
            Position entity = new Position { Name = dto.Name };
            this.positionRepository.Create(entity);
            return ToDto(entity);
        }
        public virtual PositionDto Read(long id)
        {
            return ToDto(positionRepository.Read(id));
        }
        public virtual PositionDto Update(PositionDto dto)
        {
            var entity = positionRepository.Read(dto.Id);
            this.FromDto(entity, dto);
            positionRepository.Update(entity);
            return ToDto(entity);
        }
        public virtual PositionDto Delete(long id)
        {
            var entity = positionRepository.Read(id);
            entity.Delete = true;
            positionRepository.Update(entity);
            return ToDto(entity);
        }
        #endregion 
        #region Converters
        public virtual PositionDto ToDto(Position entity)
        {
            PositionDto result = new PositionDto { Id = entity.Id, Name = entity.Name };
            return result;
        }
        public virtual void FromDto(Position entity, PositionDto dto)
        {
            entity.Name = dto.Name;
        }
        #endregion
    }
}
