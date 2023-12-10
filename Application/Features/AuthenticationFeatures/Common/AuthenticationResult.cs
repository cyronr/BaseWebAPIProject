namespace Application.Features.AuthenticationFeatures.Common;

public record AuthenticationResult
(
    ProfileDto Profile,
    string Token
);
