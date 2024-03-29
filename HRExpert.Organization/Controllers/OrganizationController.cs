﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HRExpert.Organization.Controllers
{
    using Core;
    using DTO;
    using BL.Abstractions;
    /// <summary>
    /// Контроллер организаций
    /// </summary>
    //[Authorize]
    [AllowAnonymous]
    public class OrganizationController:Controller
    {        
        private IOrganizationBL organizationBl;
        #region Ctor
        /// <summary>
        /// Конструктор организации
        /// </summary>
        /// <param name="organizationBl">БЛ организации</param>
        public OrganizationController(IOrganizationBL organizationBl)
        {
            this.organizationBl = organizationBl;
        }
        #endregion
        /// <summary>
        /// Список организаций
        /// </summary>
        /// <returns>Коллекция записей</returns>
        [HttpGet]
        [Route(CoreConstants.Api +
            CoreConstants.version +
            OrganizationConstants.OrganizationList
            )
        ]
        public virtual IEnumerable<OrganizationDto> Get()
        {
            return this.organizationBl.List();
        }
        /// <summary>
        /// Организация по идентификатору
        /// </summary>
        /// <param name="organizationid">Идентификатор</param>
        /// <returns></returns>
        [HttpGet]
        [Route(CoreConstants.Api +
            CoreConstants.version +
            OrganizationConstants.OrganizationList +
            OrganizationConstants.OrganizationKey
            )
        ]
        public virtual OrganizationDto Get(long organizationid)
        {
            return this.organizationBl.Read(organizationid);
        }
        /// <summary>
        /// Создание организации
        /// </summary>
        /// <param name="value">Организация</param>
        /// <returns></returns>
        [HttpPost]
        [Route(CoreConstants.Api +
            CoreConstants.version +
            OrganizationConstants.OrganizationList
            )
        ]
        public virtual OrganizationDto Post([FromBody]OrganizationDto value)
        {
            return this.organizationBl.Create(value);
        }
        /// <summary>
        /// Редактирование организации
        /// </summary>
        /// <param name="value">Организация</param>
        /// <returns></returns>
        [HttpPut]
        [Route(CoreConstants.Api +
            CoreConstants.version +
            OrganizationConstants.OrganizationList
            )
        ]
        public virtual OrganizationDto Put([FromBody]OrganizationDto value)
        {
            return this.organizationBl.Update(value);
        }
        /// <summary>
        /// Удаление организации
        /// </summary>
        /// <param name="organizationid">Идентификатор организации</param>
        /// <returns>Организация</returns>
        [HttpDelete]
        [Route(CoreConstants.Api +
            CoreConstants.version +
            OrganizationConstants.OrganizationList +
            OrganizationConstants.OrganizationKey
            )
        ]
        public virtual OrganizationDto Delete(long organizationid)
        {
            return this.organizationBl.Delete(organizationid);
        }

    }
}
