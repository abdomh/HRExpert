using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Core.Abstractions.Enum
{
    public enum RolesEnum
    {
        Administrator = 1,
        Employee = 2,
        Manager = 3,
        Accountant = 4,
        PersonnelManager = 5,
        Estimator = 6
    }
    public static class RoleReferency
    {
        public const string Administrator = "Администратор";
        public const string Employee = "Сотрудник";
        public const string Manager = "Руководитель";
        public const string Accountant = "Бухгалтер";
        public const string PersonnelManager = "Кадровик";
        public const string Estimator = "Расчетчик";

        public static Dictionary<RolesEnum, string> Names = new Dictionary<RolesEnum, string>
        {
            { RolesEnum.Administrator, Administrator},
            { RolesEnum.Employee, Employee},
            { RolesEnum.Manager, Manager },
            { RolesEnum.Accountant, Accountant },
            { RolesEnum.PersonnelManager, PersonnelManager },
            { RolesEnum.Estimator, Estimator }
        };
    }
}
