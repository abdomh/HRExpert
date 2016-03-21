using System;
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
        public string Name
        {
            get; set;
        }
    }
}
