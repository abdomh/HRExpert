namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository.Base
{
    public class RepositoryWithPermissions<T>: ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<T> where T: class, Models.Abstractions.IEntity
    {
        public int CurrentUserId { get; set; }
        public int CurrentRoleId { get; set; }
    }
}
