using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    /// <summary>
    /// Подразделение
    /// </summary>
    [Table("Departments")]
    public class Department : ExtCore.Data.Models.Abstractions.IEntity
    {        
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        [Column("Name")]
        public string Name
        {
            get; set;
        }
        [ForeignKey("Parent")]
        public long? ParentId { get; set; }
        /// <summary>
        /// Флаг удаления
        /// </summary>
        [Column("Delete")]
        public bool Delete
        {
            get; set;
        }
        /// <summary>
        /// Id организации
        /// </summary>
        [ForeignKey("Organization")]        
        public virtual long OrganizationId { get; set; }
        /// <summary>
        /// Организация
        /// </summary>
        public virtual Organization Organization { get; set; }
        /// <summary>
        /// Линк к дочерним подразделениям. (Текущее подразделение слева this.Left.select(x=>x.Right) - дочернии)
        /// </summary>
        public virtual ICollection<Department> Childs { get; set; }
        /// <summary>
        /// Линк к родительским подразделениям (Текущее подразделение справа this.Right.Select(x=>x.Left) - родители) 
        /// </summary>
        public virtual Department Parent { get; set; }
        /// <summary>
        /// Штатные единицы
        /// </summary>
        public virtual ICollection<StaffEstablishedPost> StaffEstablishedPosts { get; set; }
        /// <summary>
        /// Доступ
        /// </summary>
        public virtual ICollection<AccessLink> AccessLinks { get; set; }
    }
}
