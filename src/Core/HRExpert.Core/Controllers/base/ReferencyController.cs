using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using HRExpert.Core.Abstractions;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.DTO;

namespace HRExpert.Core.Controllers
{
    [Route("api/[controller]")]
    public class ReferencyController : Controller
    {
        #region Private
        IReferencyBl referencyBl;
        #endregion
        #region Public
        public IReferencyBl ReferencyBL { get { return referencyBl; } }
        #endregion
        #region Ctor
        public ReferencyController(IReferencyBl referencyBl)
        {
            this.referencyBl = referencyBl;
        }
        #endregion
        [HttpGet]
        public virtual IEnumerable<IdNameDto> Get()
        {
            return ReferencyBL.List();
        }
        [HttpGet("{id}")]
        public virtual IIdName Get(long id)
        {
            return ReferencyBL.Read(id);
        }
        [HttpPost]
        public virtual IdNameDto Post([FromBody]IdNameDto value)
        {
            return ReferencyBL.Create(value);
        }
        [HttpPut]
        public virtual IdNameDto Put([FromBody]IdNameDto value)
        {
            return ReferencyBL.Update(value);
        }
        [HttpDelete("{id}")]
        public virtual IdNameDto Delete(long id)
        {
            return ReferencyBL.Delete(id);
        }
    }
}
