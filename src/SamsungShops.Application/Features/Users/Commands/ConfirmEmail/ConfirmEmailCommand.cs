﻿using MediatR;

namespace SamsungShops.Application.Features.Users.Commands.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<UserManagerResponse>
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
