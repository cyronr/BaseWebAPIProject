using API.Requests.AuthenticationRequests;
using API.Requests.AuthenticationResponses;
using Application.Features.AuthenticationFeatures.Queries.Login;
using Application.Persistence;
using Application.Persistence.Repositories;
using AutoMapper;
using Domain.Models.ProfileModels;
using Domain.ModelsUpdateParams;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Profile = Domain.Models.ProfileModels.Profile;

namespace API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AuthenticationController(ILogger<AuthenticationController> logger, IMediator mediator, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResponse>> Login(LoginRequest request)
    {
        _logger.LogInformation($"Logging {request.Email}.");

        var query = new LoginQuery(request.Email, request.Password);
        var response = await _mediator.Send(query);

        _logger.LogInformation($"{request.Email} logged with token {response}.");

        return Ok(_mapper.Map<AuthenticationResponse>(response));
    }

    [HttpPost("createProfile")]
    public async Task<ActionResult> CreateProfile()
    {


        return Ok();
    }
}
