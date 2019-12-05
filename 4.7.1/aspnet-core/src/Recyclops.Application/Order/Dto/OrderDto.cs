using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Recyclops.Authorization.Users;
using Recyclops.PlasticOrder.Dto;
using Recyclops.PlasticSpool.Dto;
using Recyclops.PrintableObject.Dto;
using Recyclops.PrintableOrder.Dto;

namespace Recyclops.Order.Dto
{
    [AutoMap(typeof(Domains.Order.Order))]
    public class OrderDto : EntityDto
    {
        #region Properties

        public OrderDto()
        {

        }


        public OrderDto(Domains.Order.Order dom)
        {
            Id = dom.Id;
            TotalCost = dom.TotalCost;
            IsComplete = dom.IsComplete;
            ClientId = dom.ClientId;
            Client = dom.Client;
            PlasticOrders = dom.PlasticOrders;
            PrintableOrders = dom.PrintableOrders;

        }


        //Attributes
        public double TotalCost { get; set; }
        public bool IsComplete { get; set; }


        //relational
        public long ClientId { get; set; }


        //navigation
        public User Client { get; set; }
        public IList<Domains.PlasticOrder.PlasticOrder> PlasticOrders { get; set; }
        public IEnumerable<Domains.PrintableOrder.PrintableOrder> PrintableOrders { get; set; }
        #endregion

    }

    public class OrderHolder
    {
        public OrderHolder(OrderDto order, List<PlasticSpoolDto> spool, List<PrintableObjectDto> printable)
        {
            PlasticOrderDtos = spool;
            OrderDto = order;
            PrintableOrderDtos = printable;
        }

        public List<PlasticSpoolDto> PlasticOrderDtos { get; set; }

        public List<PrintableObjectDto> PrintableOrderDtos { get; set; }

        public OrderDto OrderDto { get; set; }
    }
}
