using System;
using System.ComponentModel.DataAnnotations.Schema;
using HRExpert.Core.Data.Models.Abstractions;

namespace HRExpert.Core.Data.Models.Parent
{
    public class EntityWithObject:Entity, IObject
    {
        /// <summary>
        /// Объект
        /// </summary>        
        [Column("GUID")]
        public BaseObject Object { get; set; }

        [NotMapped]
        public string Name
        {
            get { return this.Object.Name; }
            set { this.Object.Name = value; }
        }
        [NotMapped]
        public string Description
        {
            get { return this.Object.Description; }
            set { this.Object.Description = value; }
        }
        [NotMapped]
        public DateTime? CreateDate
        {
            get { return this.Object.CreateDate; }
            set { this.Object.CreateDate = value; }
        }
        [NotMapped]
        public DateTime? DeleteDate
        {
            get { return this.Object.DeleteDate; }
            set { this.Object.DeleteDate = value; }
        }
        public EntityWithObject()
        {
            this.Object = new BaseObject();
        }
    }
}
