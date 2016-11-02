using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.Data.Models
{
    public enum RoleEnum
    {
        //1	Administrator Administrator
        Administrator = 1,
        //2	Сотрудник Employee
        Employee = 2,
        //3	Руководитель Manager
        Manager = 3,
        //4	Зам.Руководителя SubManager
        SubManager = 4 ,
        //5	Кадровик PersonnelManager
        PersonnelManager = 5
    }
    public static class RoleConstants
    {
        public const string Administrator = "Администратор";
        public const string AdministratorCode = nameof(Administrator);
        public const string Employee = "Сотрудник";
        public const string EmployeeCode = nameof(Employee);
        public const string Manager = "Руководитель";
        public const string ManagerCode = nameof(Manager);
        public const string SubManager = "Зам.Руководителя";
        public const string SubManagerCode = nameof(SubManager);
        public const string PersonnelManager = "Кадровик";
        public const string PersonnelManagerCode = nameof(PersonnelManager);

        public static Dictionary<RoleEnum, string> Names = new Dictionary<RoleEnum, string>
        {
            { RoleEnum.Administrator, Administrator },
            { RoleEnum.Employee, Employee },
            { RoleEnum.Manager, Manager },
            { RoleEnum.SubManager, SubManager },
            { RoleEnum.PersonnelManager, PersonnelManager }
        };
        public static Dictionary<RoleEnum, string> Codes = new Dictionary<RoleEnum, string>
        {
            { RoleEnum.Administrator, AdministratorCode },
            { RoleEnum.Employee, EmployeeCode },
            { RoleEnum.Manager, ManagerCode },
            { RoleEnum.SubManager, SubManagerCode },
            { RoleEnum.PersonnelManager, PersonnelManagerCode }
        };
    }
}

