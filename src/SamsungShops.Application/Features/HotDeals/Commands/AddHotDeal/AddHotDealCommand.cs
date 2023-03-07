﻿using MediatR;
using SamsungShops.Application.Models;

namespace SamsungShops.Application.Features.HotDeals.Commands.AddHotDeal
{
    public class AddHotDealCommand:IRequest<HandlerResponse<HotDealResponse>>
    {
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
