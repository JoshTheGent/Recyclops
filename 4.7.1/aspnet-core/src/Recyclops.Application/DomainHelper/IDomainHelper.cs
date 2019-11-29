using System;
using System.Collections.Generic;
using System.Text;

namespace Recyclops.DomainHelper
{
    public interface IDomainHelper
    {
        /// <summary>
        /// Checks to see if database is empty and adds values to it
        /// </summary>
        void UploadData();


    }
}
