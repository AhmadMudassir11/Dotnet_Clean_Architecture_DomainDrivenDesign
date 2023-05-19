using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using BuberDinner.Application.Services.Authentication.Common;

namespace BuberDinner.Application.Services.Authentication.Queries
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            // Check user exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // Validate Password
            if (user.Password != password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // Create Token
            var token = _jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult(user, token);
        }
    }
}
