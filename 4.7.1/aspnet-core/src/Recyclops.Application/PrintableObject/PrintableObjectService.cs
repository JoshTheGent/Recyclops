using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Recyclops.PrintableObject.Dto;

namespace Recyclops.PrintableObject
{
    public class PrintableObjectService: AsyncCrudAppService<Domains.PrintableObject.PrintableObject, PrintableObjectDto, int>, IPrintableObjectService
    {

    #region Properties



    #endregion


    #region Constructor

    public PrintableObjectService(IRepository<Domains.PrintableObject.PrintableObject, int> repository) : base(repository)
    {
    }

    #endregion


    #region Methods

    public List<PrintableObjectDto> GetAllIncluding()
    {
        var dom = Repository
            .GetAll()
            .Include(x=>x.PlasticSpool)
            .ThenInclude(x=>x.Plastic)
            .ThenInclude(x=>x.LocationSource)
            .Include(x=>x.PrintableOrders)
            .ThenInclude(x=>x.Order)
            .ToList();

        var dto = dom.Select(x => new PrintableObjectDto(x)).ToList();

        return dto;
    }


    #endregion
    }

}

