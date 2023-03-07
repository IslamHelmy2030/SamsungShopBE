using MediatR;
using SamsungShops.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsungShops.Application.Features.HotDeals.Commands.UpdateHotDeal
{
    public class UpdateHotDealCommand : IRequest<HandlerResponse<HotDealResponse>>
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ImageFile { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public bool IsVisible { get; set; }
        public int? DiscountId { get; set; }
        public int? ProductId { get; set; }
        public string? ImageBase64 { get; set; }
    }
}
