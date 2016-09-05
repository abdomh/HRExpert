using System;
using Platformus.Barebone;
namespace HRExpert.Organization.BL
{
    public class BaseBL: Abstractions.IBaseBl
    {
        protected IHandler handler;

        public virtual void SetHandler(IHandler handler)
        {
            this.handler = handler;
        }
    }
}
