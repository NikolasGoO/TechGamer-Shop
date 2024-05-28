using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TechGamer.Application.DTOs.Request;
using TechGamer.Application.DTOs.Response;
using TechGamer.Application.Interfaces;
using TechGamer.Infra.Identity.Configurations;

namespace TechGamer.Infra.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtOptions _jwtOptions;

        public IdentityService(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<UserRegisteredResponse> RegisterUser(UserRegisteredRequest request)
        {
            var identityUser = new IdentityUser
            {
                UserName = request.Email,
                Email = request.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(identityUser, request.Password);

            if (result.Succeeded)
            {
                await _userManager.SetLockoutEnabledAsync(identityUser, false);
            }

            var userRegisteredResponse = new UserRegisteredResponse(result.Succeeded);

            if (!result.Succeeded && result.Errors.Count() > 0)
            {
                userRegisteredResponse.AddErrors(result.Errors.Select(e => e.Description));
            }

            return userRegisteredResponse;

        }

        public async Task<UserLoginResponse> Login(UserLoginRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(userName: request.Email,
                password: request.Password,
                isPersistent: false,
                lockoutOnFailure: true);

            if (result.Succeeded)
            {
                return await SetToken(request.Email);
            }

            var userLoginResponse = new UserLoginResponse(result.Succeeded);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    userLoginResponse.AddError("Esta conta está bloqueada.");
                }
                else if (result.IsNotAllowed)
                {
                    userLoginResponse.AddError("Esta conta não tem permissão para fazer login.");
                }
                else if (result.RequiresTwoFactor)
                {
                    userLoginResponse.AddError("É necessário confirmar o login no seu segundo fato de " +
                        "autenticação.");
                }
                else
                {
                    userLoginResponse.AddError("Usuário ou senha estão incorretos.");
                }
            }

            return userLoginResponse;

        }

        private async Task<IList<Claim>> GetClaims(IdentityUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            }

            return claims;
        }

        private async Task<UserLoginResponse> SetToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var tokenClaims = await GetClaims(user);

            var expirationDate = DateTime.Now.AddSeconds(_jwtOptions.Expiration);

            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: tokenClaims,
                notBefore: DateTime.Now,
                expires: expirationDate,
                signingCredentials: _jwtOptions.SigningCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new UserLoginResponse(
                success: true,
                token: token,
                expirationDate: expirationDate);

        }
    }
}
