using ExtCore.Data.Abstractions;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Core.Data.Abstractions;
namespace HRExpert.Core.BL
{
    public class BaseBL: Abstractions.IBaseBL
    {
        #region Private
        private IStorage storage;
        private IAuthService authService;       
        private IUserRepository userRepository;
        private ICredentialRepository credentialRepository;
        private IRoleRepository roleRepository;
        private ISectionRepository sectionRepository;
        private IPermissionTypesRepository permissionRepository;
        #endregion
        #region Public
        public IStorage Storage { get { return storage; } }
        public IAuthService AuthService { get { return authService; } }
        public IUserRepository UserRepository { get { return userRepository; } }
        public ICredentialRepository CredentialRepository { get { return credentialRepository; } }
        public IRoleRepository RoleRepository { get { return roleRepository; } }
        public IPermissionTypesRepository PermissionsRepository { get { return permissionRepository; } }

        public ISectionRepository SectionRepository { get { return sectionRepository; } }
        #endregion
        public BaseBL(IStorage storage, IAuthService authService)
        {
            this.storage = storage;
            this.authService = authService;

            this.userRepository = storage.GetRepository<IUserRepository>();
            this.credentialRepository = storage.GetRepository<ICredentialRepository>();
            this.roleRepository = storage.GetRepository<IRoleRepository>();
            this.sectionRepository = storage.GetRepository<ISectionRepository>();
            this.permissionRepository = storage.GetRepository<IPermissionTypesRepository>();
        }       

        #region Private methods
        
        #endregion
    }
}
