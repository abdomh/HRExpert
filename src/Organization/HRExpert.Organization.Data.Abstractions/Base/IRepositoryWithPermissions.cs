namespace HRExpert.Organization.Data.Abstractions.Base
{
    public interface IRepositoryWithPermissions: IRepository
    {
        int CurrentUserId { get; set; }
        int CurrentRoleId { get; set; }
    }
}
