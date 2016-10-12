using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.DTO
{
    public class DocumentApprovementDto
    {
        private Dictionary<int, string> Labels = new Dictionary<int, string> {
            { 1,"Сотрудник"},
            { 2,"Руководитель"},
            { 3,"Кадровик"}
        };
        private Func<DocumentApprovementDto, bool> IsApproveAvailable = (x) => { return !x.isAccept; };
        public void SetApproveCheck(Func<DocumentApprovementDto, bool> IsApproveAvailable)
        {
            this.IsApproveAvailable = IsApproveAvailable;
        }
        public void SetLabelsDictionary(Dictionary<int, string> labels) => this.Labels = labels;
        public bool IsEditable
        {
            get { return IsApproveAvailable(this); }
        }
        public bool isAccept {get;set;}
        public int ApprovePosition { get; set; }
        public string Label
        {
            get { return ApprovePosition>0 && ApprovePosition<=Labels.Keys.Max()?Labels[ApprovePosition]:""; }            
        }
        public PersonDto Person { get; set; }
        public PersonDto RealPerson { get; set; }
        public DateTime? DateAccept { get; set; }
    }
}
