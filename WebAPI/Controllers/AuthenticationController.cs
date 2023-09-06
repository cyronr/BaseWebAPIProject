using AutoMapper;
using API.Requests.AuthenticationRequests;
using Application.Features.AuthenticationFeatures.Queries.Login;
using API.Requests.AuthenticationResponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [SwaggerResponse(200, "Sukces. Zwrócono odpowiedź.")]
    [SwaggerResponse(204, "Sukces. Brak odpowiedzi.")]
    [SwaggerResponse(400, "Błąd. Niepoprawny request.")]
    [SwaggerResponse(401, "Błąd. Brak autoryzacji.")]
    [SwaggerResponse(403, "Błąd. Zabroniono.")]
    [SwaggerResponse(404, "Błąd. Nie znaleziono obiektu.")]
    [SwaggerResponse(407, "Błąd. Wystąpił błąd biznesowy.")]
    [SwaggerResponse(500, "Nieoczekiwany błąd.")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ILogger<AuthenticationController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
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

    }
}
