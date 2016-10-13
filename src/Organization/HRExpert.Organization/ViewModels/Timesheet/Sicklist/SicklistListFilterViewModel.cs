using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace HRExpert.Organization.ViewModels
{
    using DTO;
    public class SicklistListFilterViewModel: FilterViewModelBase
    {
        [ContentFilter(ModelPropertyName ="Document.Person.Name", CheckAction = ContentFilterActions.StartsWith)]
        public string PersonName { get; set; }
        [ContentFilter(ModelPropertyName = "Document.Person.DepartmentId", CheckAction = ContentFilterActions.Equals)]
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        [ContentFilter(ModelPropertyName = "Document.Event.BeginDate", CheckAction = ContentFilterActions.GreatOrEquals)]
        public DateTime? BeginDate { get; set; }
        [ContentFilter(ModelPropertyName = "Document.Event.EndDate", CheckAction = ContentFilterActions.LessOrEquals)]
        public DateTime? EndDate { get; set; }
    }
}
