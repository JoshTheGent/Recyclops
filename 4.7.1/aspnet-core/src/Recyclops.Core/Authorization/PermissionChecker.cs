using Abp.Authorization;
using Recyclops.Authorization.Roles;
using Recyclops.Authorization.Users;

namespace Recyclops.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
