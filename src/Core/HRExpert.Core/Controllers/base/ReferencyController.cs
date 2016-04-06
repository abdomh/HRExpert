using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using HRExpert.Core.Abstractions;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.DTO;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HRExpert.Core.Controllers
{
    [Route("api/[controller]")]
    public class ReferencyController : Controller
    {
        #region Private
        IReferencyBl referencyBl;
        #endregion
        #region Public
        IReferencyBl ReferencyBL { get { return referencyBl; } }
        #endregion
        #region Ctor
        public ReferencyController(IReferencyBl referencyBl)
        {
            this.referencyBl = referencyBl;
        }
        #endregion
        // GET: api/values
        [HttpGet]
        [Authorize]
        public virtual IEnumerable<IdNameDto> Get()
        {
            return ReferencyBL.List();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public virtual IIdName Get(long id)
        {
            return ReferencyBL.Read(id);
        }

        // POST api/values
        [HttpPost]
        public virtual IdNameDto Post([FromBody]IdNameDto value)
        {
            return ReferencyBL.Create(value);
        }

        // PUT api/values/5
        [HttpPut]
        public virtual IdNameDto Put([FromBody]IdNameDto value)
        {
            return ReferencyBL.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public virtual IdNameDto Delete(long id)
        {
            return ReferencyBL.Delete(id);
        }
    }
}
