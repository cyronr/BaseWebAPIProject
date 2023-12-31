﻿using Application.Features.AuthenticationFeatures.Common;
using MediatR;

namespace Application.Features.AuthenticationFeatures.Queries.Login
{
    public record LoginQuery
    (
        string Email,
        string Password
    ) : IRequest<AuthenticationResult>;
}
