using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.DTO;
using HRExpert.Organization.Data.Abstractions;
using ExtCore.Data.Abstractions;
using Platformus.Barebone;
namespace HRExpert.Organization.BL
{
    using Converters;
    public class DepartmentBL : Abstractions.IDepartmentBL
    {        
        private IHandler handler;
        private IDepartmentRepository departmentRepository;
        public DepartmentBL(IHandler handler)
        {
            this.departmentRepository = handler.Storage.GetRepository<IDepartmentRepository>();
            this.handler = handler;
        }

        #region Public
        public IEnumerable<DepartmentDto> List()
        {
            var all = departmentRepository.All();            
            var allDepartments = all.Select(x => x.Convert()).ToList();            
            return allDepartments;
        }
        public IEnumerable<DepartmentDto> ListByOrganization(int OrganizationId)
        {
            var all = departmentRepository.AllByOrganization(OrganizationId);
            return all.Select(x => x.Convert()).ToList();            
        }
        public IEnumerable<DepartmentDto> ListByOrganizationAndDepartment(int OrganizationId,int DepartmentId)
        {
            var all = departmentRepository.ReadWithChildsAndParents(DepartmentId).Childs;
            return all.Select(x => x.Convert()).ToList();
        }
        public DepartmentDto ByOrganizationAndKey(int organizationid, int departmentid)
        {
            var entity = this.departmentRepository.ByOrganizationAndKey(organizationid, departmentid);
            return entity.Convert();
        }
        public virtual DepartmentDto Create(DepartmentDto dto)
        {
            var entity = new Department { Name = dto.Name };
            this.departmentRepository.Create(entity);
            return entity.Convert();
        }
        public virtual void AddDepartmentToDepartment(int targetdepartmentid, int departmentid)
        {
            
        }
        public virtual DepartmentDto Read(int id)
        {
            return (departmentRepository.Read(id)).Convert();
        }
        public virtual DepartmentDto Update(DepartmentDto dto)
        {
            var entity = departmentRepository.Read(dto.Id);
            this.FromDto(entity, dto);
            departmentRepository.Update(entity);
            return entity.Convert();
        }
        public virtual DepartmentDto Delete(int id)
        {
            var entity = departmentRepository.Read(id);
            entity.Delete = true;
            departmentRepository.Update(entity);
            return entity.Convert();
        }
        #region Converters        
        public void FromDto(Department entity, DepartmentDto indto)
        {
            var dto = (DepartmentDto)indto;
            entity.Name = dto.Name;            
        }
        #endregion
        
        #endregion
    }
}
