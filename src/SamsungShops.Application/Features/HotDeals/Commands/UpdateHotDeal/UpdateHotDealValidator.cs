using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsungShops.Application.Features.HotDeals.Commands.UpdateHotDeal
{
    public class UpdateHotDealValidator :AbstractValidator<UpdateHotDealCommand>
    {
        public UpdateHotDealValidator()
        {
            RuleFor(hot => hot.Price).NotEmpty()
                .WithMessage("Price is required");
            RuleFor(hot => hot.ImageFile).NotEmpty()
                .WithMessage("ImageFile is required");
        }
    }
}
