﻿using System;
using HRExpert.Organization.Data.Models;
using HRExpert.Core.Services.Abstractions;
using ExtCore.Data.Abstractions;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Organization.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace HRExpert.Organization.BL
{
    public class PersonsBL : Abstractions.IPersonBL
    {
        private IPersonRepository personsRepository;
        private IAuthService authService;
        public PersonsBL(IStorage storage, IAuthService authService)
        {
            this.personsRepository = storage.GetRepository<IPersonRepository>();
            var StaffEstablishedPostPermissions = StaffEstablishedPostBL.CreatePermissionsExpression(authService.CurrentUser.Id);
            ParameterExpression param = Expression.Parameter(typeof(Person));            
            var property = Expression.Property(param, typeof(Person), "StaffEstablishedPost");
            //this.personsRepository.PermissionExpression = Expression.Lambda<Func<Person,bool>>(Expression.IsTrue(Expression.Invoke(StaffEstablishedPostPermissions, property)), param);
                //(x) => x.UserId==authService.CurrentUser.Id || x.StaffEstablishedPost.Department.AccessLinks.Where(y => y.Person.UserId == authService.CurrentUser.Id).Count() > 0;
            this.authService = authService;
        }
        public List<PersonDto> GetByStaffEstablishedPost(long OrganizationId, long DepartmentId, long PositionId)
        {
            var result = new List<PersonDto>();
            var data = personsRepository.GetByStaffEstablishedPost(OrganizationId, DepartmentId, PositionId);
            if (data != null)
                result = data.Select(x => new PersonDto { Name = x.Name, Id = x.Id, PostCount = x.PostCount, PositionId=x.PositionId, DepartmentId =x.DepartmentId }).ToList();
            return result;
        }
        public PersonDto GetByStaffEstablishedPostAndId(long OrganizationId, long DepartmentId, long PositionId,long PersonId)
        {
            PersonDto result = null;
            var data = personsRepository.GetByStaffEstablishedPostAndId(OrganizationId, DepartmentId, PositionId, PersonId);
            if (data != null)
                result = new PersonDto { Name = data.Name, Id = data.Id, PostCount = data.PostCount, DepartmentId=data.DepartmentId, PositionId=data.PositionId };
            return result;
        }
        public void Create(PersonDto dto)
        {
            Person entity = new Person();
            entity.Name = dto.Name;
            entity.PostCount = dto.PostCount;            
        }
    }
}
