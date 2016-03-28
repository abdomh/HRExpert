using System;
using System.ComponentModel.DataAnnotations.Schema;
using HRExpert.Core.Data.Models.Abstractions;
namespace HRExpert.Core.Data.Models.Parent
{
    /// <summary>
    /// Базовый класс справочников
    /// </summary>
    public class Referency : Entity, IReferency
    {
        /// <summary>
        /// Название
        /// </summary>
        [Column("Name")]
        public string Name
        {
            get; set;
        }
        /// <summary>
        /// Код
        /// </summary>
        [Column("Code")]
        public string Code
        {
            get;set;
        }
       
    }
}
