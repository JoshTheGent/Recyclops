using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Recyclops.PrintableObject.Dto;

namespace Recyclops.PrintableObject
{
    public interface IPrintableObjectService: IAsyncCrudAppService<PrintableObjectDto, int>
    {


        List<PrintableObjectDto> GetAllIncluding();
    }
}
