using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recyclops.DomainHelper
{
    public interface IDomainHelper
    {
        Task<List<int>> UploadLocations();
        Task<List<int>> UploadPlastics(List<int> locIds);
        Task<List<int>> UploadSpools(List<int> plasticIds);
        Task<List<int>> UploadPrintables(List<int> spoolIds);
        bool UploadCheck();
    }
}
