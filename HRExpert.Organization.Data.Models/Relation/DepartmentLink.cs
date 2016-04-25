using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    /// <summary>
    /// Связь между подразделениями
    /// </summary>
    [Table("DepartmentLinks")]
    public class DepartmentLink
    {
        /// <summary>
        /// Id левого подразделения(родитель)
        /// </summary>
        [ForeignKey("Left")]
        public virtual long LeftId { get; set; }
        /// <summary>
        /// Id правого подразделения(дочернее)
        /// </summary>
        [ForeignKey("Right")]
        public virtual long RightId { get; set; }
        /// <summary>
        /// Левое подразделение(родитель)
        /// </summary>
        public virtual Department Left { get; set; }
        /// <summary>
        /// Правое подразделение(дочернее)
        /// </summary>
        public virtual Department Right { get; set; }
    }
}
