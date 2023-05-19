using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{

    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {

        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {

            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            //return Ok(request);
            var command = _mapper.Map<RegisterCommand>(request);

            ErrorOr<AuthenticationResult> authResponse = await _mediator.Send(command);

            #region CQRS 
            //ErrorOr <AuthenticationResult> authResponse = _authenticationCommandService.Register(
            //    request.FirstName,
            //    request.LastName,
            //    request.Email,
            //    request.Password);
            #endregion

            return authResponse.Match(
                authResponse => Ok(_mapper.Map<AuthenticationResponse>(authResponse)),
                errors => Problem(errors)
                );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            #region CRQS
            //var authResponse = _authenticationQueryService.Login(
            //    request.Email,
            //    request.Password);
            #endregion

            var query = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationResult> authResponse = await _mediator.Send(query);
            if (authResponse.IsError && authResponse.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized,
                  title: authResponse.FirstError.Description
                    );
            }

            return authResponse.Match(
                authResponse => Ok(_mapper.Map<AuthenticationResponse>(authResponse)),
                errors => Problem(errors)
                );

        }
        
    }
}
