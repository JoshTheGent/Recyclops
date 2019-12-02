using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Recyclops.Authorization.Users;

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
}
