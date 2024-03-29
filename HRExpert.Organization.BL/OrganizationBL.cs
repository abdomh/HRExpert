﻿using ExtCore.Data.Abstractions;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Organization.DTO;
using System.Collections.Generic;
using System.Linq;
namespace HRExpert.Organization.BL
{
    public class OrganizationBL: Abstractions.IOrganizationBL
    {
        private IOrganizationRepository organizationRepository;
        private IAuthService authService;
        public OrganizationBL(IStorage storage, IAuthService authService )           
        {
            this.organizationRepository = storage.GetRepository<IOrganizationRepository>();
            this.authService = authService;
        }
        #region CRUD
        public virtual IEnumerable<OrganizationDto> List()
        {
            return this.organizationRepository.All().Select(x => ToDto(x));
        }
        public virtual OrganizationDto Create(OrganizationDto dto)
        {
            Data.Models.Organization entity = new Data.Models.Organization { Name = dto.Name };
            this.organizationRepository.Create(entity);
            return ToDto(entity);
        }
        public virtual OrganizationDto Read(long id)
        {
            return ToDto(organizationRepository.Read(id));
        }
        public virtual OrganizationDto Update(OrganizationDto dto)
        {
            var entity = organizationRepository.Read(dto.Id);
            this.FromDto(entity, dto);
            organizationRepository.Update(entity);
            return ToDto(entity);
        }
        public virtual OrganizationDto Delete(long id)
        {
            var entity = organizationRepository.Read(id);
            entity.Delete = true;
            organizationRepository.Update(entity);
            return ToDto(entity);
        }
        #endregion 
        #region Converters
        public virtual OrganizationDto ToDto(Data.Models.Organization entity)
        {
            OrganizationDto result = new OrganizationDto { Id = entity.Id, Name = entity.Name };
            return result;
        }
        public virtual void FromDto(Data.Models.Organization entity, OrganizationDto dto)
        {
            entity.Name = dto.Name;
        }
        #endregion
    }
}
