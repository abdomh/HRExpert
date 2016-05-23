﻿using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.DTO;
using HRExpert.Organization.Data.Abstractions;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Services.Abstractions;
namespace HRExpert.Organization.BL
{
    public class DepartmentBL : Abstractions.IDepartmentBL
    {
        private IAuthService authService;
        private IDepartmentRepository departmentRepository;
        public DepartmentBL(IStorage storage, IAuthService authService)
        {
            this.departmentRepository = storage.GetRepository<IDepartmentRepository>();
            this.authService = authService;
        }

        #region Public
        public IEnumerable<DepartmentDto> List()
        {
            var all = departmentRepository.All();            
            var allDepartments = all.Select(x => new DepartmentDto { Id = x.Id, Name = x.Name }).ToList();            
            return allDepartments;
        }
        public IEnumerable<DepartmentDto> ListByOrganization(long OrganizationId)
        {
            var all = departmentRepository.AllByOrganization(OrganizationId);
            return all.Select(x => new DepartmentDto { Id = x.Id, Name = x.Name }).ToList();            
        }
        public IEnumerable<DepartmentDto> ListByOrganizationAndDepartment(long OrganizationId,long DepartmentId)
        {
            var all = departmentRepository.ReadWithChildsAndParents(DepartmentId).Childs;
            return all.Select(x => new DepartmentDto { Id = x.Id, Name = x.Name }).ToList();
        }
        public DepartmentDto ByOrganizationAndKey(long organizationid, long departmentid)
        {
            var entity = this.departmentRepository.ByOrganizationAndKey(organizationid, departmentid);
            return ToDto(entity);
        }
        public virtual DepartmentDto Create(DepartmentDto dto)
        {
            var entity = new Department { Name = dto.Name };
            this.departmentRepository.Create(entity);
            return ToDto(entity);
        }
        public virtual void AddDepartmentToDepartment(long targetdepartmentid, long departmentid)
        {
            
        }
        public virtual DepartmentDto Read(long id)
        {
            return ToDto(departmentRepository.Read(id));
        }
        public virtual DepartmentDto Update(DepartmentDto dto)
        {
            var entity = departmentRepository.Read(dto.Id);
            this.FromDto(entity, dto);
            departmentRepository.Update(entity);
            return ToDto(entity);
        }
        public virtual DepartmentDto Delete(long id)
        {
            var entity = departmentRepository.Read(id);
            entity.Delete = true;
            departmentRepository.Update(entity);
            return ToDto(entity);
        }
        #region Converters
        public DepartmentDto ToDto(Department entity)
        {
            DepartmentDto result = new DepartmentDto();
            result.Id = entity.Id;
            result.Name = entity.Name;
            result.OrganizationId = entity.OrganizationId;            
            return result;
        }
        public void FromDto(Department entity, DepartmentDto indto)
        {
            var dto = (DepartmentDto)indto;
            entity.Name = dto.Name;            
        }
        #endregion
        
        #endregion
    }
}
