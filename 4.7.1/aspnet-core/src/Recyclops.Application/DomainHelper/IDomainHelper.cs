using System;
using System.Collections.Generic;
using System.Text;

namespace Recyclops.DomainHelper
{
    public interface IDomainHelper
    {
        void UploadLocations();
        void UploadPlastics();
        void UploadSpools();
        void UploadPrintables();
    }
}
