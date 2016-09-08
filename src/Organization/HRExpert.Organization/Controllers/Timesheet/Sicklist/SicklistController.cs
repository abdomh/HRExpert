﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Abstractions;
using ExtCore.Data.Abstractions;
namespace HRExpert.Organization.Controllers.Timesheet.Sicklist
{
    /// <summary>
    /// Контроллер больничных
    /// </summary>
    public class SicklistController :Platformus.Barebone.Controllers.ControllerBase
    {
        ISicklistBL sicklistBL;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sicklistBL"></param>
        public SicklistController(IStorage storage, ISicklistBL sicklistBL)
            :base(storage)
        {
            this.sicklistBL = sicklistBL;
        }
        #region API
        /*
        /// <summary>
        /// Список
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<DocumentDto<SicklistDto>> List()
        {
            return sicklistBL.List();
        }
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="sicklistid"></param>
        /// <returns></returns>
        [HttpGet]
        public DocumentDto<SicklistDto> Read(int sicklistid)
        {
            return sicklistBL.Read(sicklistid);
        }
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]        
        public DocumentDto<SicklistDto> Create([FromForm]DocumentDto<SicklistDto> value)
        {           
           return sicklistBL.Create(value);           
        }
        /// <summary>
        /// Редактирование
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public DocumentDto<SicklistDto> Update([FromForm]DocumentDto<SicklistDto> value)
        {
            return sicklistBL.Update(value);
        }*/
        #endregion
        #region MVC
        [HttpGet]
        public IActionResult Index()
        {
            sicklistBL.SetHandler(this);
            var model = sicklistBL.List();
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            sicklistBL.SetHandler(this);
            var model = sicklistBL.Read(Id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(DocumentDto<SicklistDto> model)
        {
            sicklistBL.SetHandler(this);
            model = sicklistBL.Update(model);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new DocumentDto<SicklistDto>();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(DocumentDto<SicklistDto> model)
        {
            model = sicklistBL.Create(model);
            return RedirectToAction("Edit", "Sicklist", new { Id = model.Data.Id });
        }
        #endregion
    }
}
