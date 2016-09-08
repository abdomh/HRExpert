﻿using System;
using HRExpert.Organization.Data.Models;
using ExtCore.Data.Abstractions;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Organization.DTO;
using System.Collections.Generic;
using System.Linq;
using Platformus.Barebone;
using Platformus.Security;
namespace HRExpert.Organization.BL
{
    using Converters;
    public class PersonsBL : BaseBL, Abstractions.IPersonBL
    {
        private IPersonRepository personsRepository;
        public override void SetHandler(IHandler handler)
        {
            base.SetHandler(handler);
            this.personsRepository = handler.Storage.GetRepository<IPersonRepository>();
        }
        public PersonsBL()
        {            
        }
        public List<PersonDto> List()
        {
            return this.personsRepository.All().Select(x=>x.Convert()).ToList();
        }
        public PersonDto Read(int Id)
        {
            return this.personsRepository.Read(Id).Convert();
        }
        public List<PersonDto> GetByStaffEstablishedPost(int OrganizationId, int DepartmentId, int PositionId)
        {
            var result = new List<PersonDto>();
            var data = personsRepository.GetByStaffEstablishedPost(OrganizationId, DepartmentId, PositionId);
            if (data != null)
                result = data.Select(x => x.Convert()).ToList();
            return result;
        }
        public PersonDto GetByStaffEstablishedPostAndId(int OrganizationId, int DepartmentId, int PositionId,int PersonId)
        {
            PersonDto result = null;
            var data = personsRepository.GetByStaffEstablishedPostAndId(OrganizationId, DepartmentId, PositionId, PersonId);
            if (data != null)
                result = data.Convert();
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