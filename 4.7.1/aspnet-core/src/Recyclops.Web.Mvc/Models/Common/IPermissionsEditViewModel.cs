using System.Collections.Generic;
using Recyclops.Roles.Dto;

namespace Recyclops.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}