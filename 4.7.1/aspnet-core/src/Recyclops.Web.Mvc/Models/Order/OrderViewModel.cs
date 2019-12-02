using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recyclops.Order.Dto;

namespace Recyclops.Web.Models.Order
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {

        }

        public OrderViewModel(List<Recyclops.PrintableObject.Dto.PrintableObjectDto> printables, List<Recyclops.PlasticSpool.Dto.PlasticSpoolDto> plastics)
        {
            PrintableOrders = printables.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            PlasticOrders = plastics.Select(x => new SelectListItem(x.Mass + " -- " + x.Plastic.Name, x.Id.ToString()));
        }


        public OrderViewModel(Recyclops.Order.Dto.OrderDto dto)
        {
            Id = dto.Id;
            TotalCost = dto.TotalCost;
            NumItems = dto.PlasticOrders.Count() + dto.PrintableOrders.Count();
            IsComplete = dto.IsComplete;
            ClientId = dto.ClientId;
            ClientName = dto.Client.FullName;
            var items = "";
            foreach (var plasticOrder in dto.PlasticOrders)
            {
                items += plasticOrder.PlasticSpool.Plastic.Name + ", ";
            }

            foreach (var printableOrder in dto.PrintableOrders)
            {
                items += printableOrder.PrintableObject.Name + ", ";
            }

            Bought = items;

        }

        public OrderViewModel(Recyclops.Order.Dto.OrderDto dto, List<Recyclops.PrintableObject.Dto.PrintableObjectDto> printables, List<Recyclops.PlasticSpool.Dto.PlasticSpoolDto> plastics)
        {
            Id = dto.Id;
            TotalCost = dto.TotalCost;
            NumItems = dto.PlasticOrders.Count() + dto.PrintableOrders.Count();
            IsComplete = dto.IsComplete;
            ClientId = dto.ClientId;
            ClientName = dto.Client.FullName;
            var items = "";
            foreach (var plasticOrder in dto.PlasticOrders)
            {
                items += plasticOrder.PlasticSpool.Plastic.Name + ", ";
            }

            foreach (var printableOrder in dto.PrintableOrders)
            {
                items += printableOrder.PrintableObject.Name + ", ";
            }

            Bought = items;

            PrintableOrders = printables.Select(x => new SelectListItem(x.Name + ": $" + x.SellValue, x.Id.ToString()));
            PlasticOrders = plastics.Select(x => new SelectListItem(x.Mass + " -- " + x.Plastic.Name + ": $" + x.SellValue, x.Id.ToString()));
        }


        //Attributes
        public int Id { get; set; }
        public double TotalCost { get; set; }
        public int NumItems { get; set; }
        public bool IsComplete { get; set; }
        public string Bought { get; set; }
        public long ClientId { get; set; }
        public string ClientName { get; set; }



        //selected

        public IEnumerable<SelectListItem> PlasticOrders { get; set; }
        public IEnumerable<SelectListItem> PrintableOrders { get; set; }
        public IList<int> PlasticOrderIds { get; set; }
        public IList<int> PrintableOrderIds { get; set; }

        public OrderDto DtoModel()
        {
            return new OrderDto
            {
                Id = Id,
                IsComplete = false

            };
        }


    }
}
