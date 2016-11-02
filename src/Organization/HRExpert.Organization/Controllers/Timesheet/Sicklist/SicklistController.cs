using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Abstractions;
using ExtCore.Data.Abstractions;
namespace HRExpert.Organization.Controllers.Timesheet.Sicklist
{
    using ViewModels;
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
        public SicklistController(IStorage storage, ISicklistBL sicklistBL, IPersonEventBL personEventBL)
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
            SicklistListViewModel model = new SicklistListViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(SicklistListViewModel model)
        {
            model.Documents = this.sicklistBL.GetByFilterModel(model.Filter);
           
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var model = sicklistBL.Read(Id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(DocumentDto<SicklistDto> model)
        {
            Validate(model);
            if (ModelState.IsValid)
            {
                model = sicklistBL.Update(model);
            }
            else
            {
                model = sicklistBL.Read(model.Data.Id);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new DocumentDto<SicklistDto>();
            model.Approvements.Add(new DocumentApprovementDto() { ApprovePosition = 1 });
            model.Approvements.Add(new DocumentApprovementDto() { ApprovePosition = 2 });
            model.Approvements.Add(new DocumentApprovementDto() { ApprovePosition = 3 });
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(DocumentDto<SicklistDto> model)
        {
            Validate(model);
            if (ModelState.IsValid)
            {
                model = sicklistBL.Create(model);
                return RedirectToAction("Edit", "Sicklist", new { Id = model.Data.Id });
            }
            else return View(model);
        }

        public void Validate(DocumentDto<SicklistDto> model)
        {
            ModelState.Clear();
            if(model.Data.Id==0)
            {
                if (model.Data.SicklistDocument == null)
                    ModelState.AddModelError("Data.SicklistDocument", "Скан больничного листа обязателен");
            }
            if(!model.Data.BeginDate.HasValue)
            {
                ModelState.AddModelError("Data.BeginDate", "Дата начала обязательна");
            }
            if (!model.Data.EndDate.HasValue)
            {
                ModelState.AddModelError("Data.BeginDate", "Дата окончания обязательна");
            }
            if(model.Data.EndDate<model.Data.BeginDate)
            {
                ModelState.AddModelError("Data.BeginDate", "Дата начала должна быть меньше даты окончания");
            }
            if (string.IsNullOrEmpty(model.Data.SicklistNumber))
            {
                ModelState.AddModelError("Data.SicklistNumber", "Номер больничного обязателен");
            }
            if(model.Data.BeginDate.HasValue && model.Data.EndDate.HasValue)
            {                
                if(sicklistBL.CheckOtherDocuments(model))
                {
                    ModelState.AddModelError("Person.Id", "Для выбранного сотрудника существуют другие заявки в указаном интервале дат.");
                }
            }

        }
        [HttpGet]
        public IActionResult GetFile(int SicklistId, int fileType)
        {
            string filename;
            return File(sicklistBL.GetFile(SicklistId, fileType, out filename), "application/octet-stream", filename);
        }
        #endregion
    }
}
