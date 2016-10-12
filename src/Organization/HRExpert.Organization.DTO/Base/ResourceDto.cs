using System.Linq;
using System.Collections.Generic;
namespace HRExpert.Organization.DTO
{
    /// <summary>
    /// Родительский класс для всех ресурсов
    /// </summary>
    public class ResourceDto
    {
        public bool IsEditable { get; set; }
        public IEnumerable<string> ResourcePermissions { get; set; }
        public bool IsHasPermission(string code)
        {
            return this.ResourcePermissions.Any(x => x == code);
        }
    }
}
