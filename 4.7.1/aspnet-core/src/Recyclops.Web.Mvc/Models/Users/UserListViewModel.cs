using System.Collections.Generic;
using Recyclops.Roles.Dto;
using Recyclops.Users.Dto;

namespace Recyclops.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
