using IdentityService;
using IdentityService.Application;
using IdentityService.Application.Features;
using IdentityService.Application.Features.InternalTreatement.Login;
using IdentityService.Contracts.Constant;
using IdentityService.Domain.Models.Dbo;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace IdentityService.Application.Features.InternalTreatement.Login;

public class LoginCommandHandler(UserManager<ApplicationUser> userManager, IConfiguration configuration) :
    IRequestHandler<LoginCommand, ApiResponse<LoginResponse>>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;

    public async Task<ApiResponse<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        ApplicationUser? user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return new ApiResponse<LoginResponse>()
            {
                Succeeded = false,
                Error = new ProblemDetails()
                {
                    Title = nameof(ErrorDetails.InvalidEmail),
                    Detail = ErrorDetails.InvalidEmail,
                    Status = 400,
                },
            };
        }

        bool hasPassword = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!hasPassword)
        {
            return new ApiResponse<LoginResponse>()
            {
                Succeeded = false,
                Error = new ProblemDetails()
                {
                    Title = nameof(ErrorDetails.InvalidPassword),
                    Detail = ErrorDetails.InvalidPassword,
                    Status = 400,
                },
            };
        }

        IList<Claim> claims = await _userManager.GetClaimsAsync(user);
        IList<string> roles = await _userManager.GetRolesAsync(user);

        IEnumerable<Claim> claim = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!), new Claim("uid", user.Id),
                new Claim("roles", string.Join(',', roles)),
            }
            .Union(claims);

        SymmetricSecurityKey symmetricSecurityKey =
            new(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

        JwtSecurityToken token = new(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddDays(1),
            claims: claim,
            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256));

        return new ApiResponse<LoginResponse>()
        {
            Succeeded = true,
            Data = new LoginResponse() { Token = new JwtSecurityTokenHandler().WriteToken(token) },
        };
    }
}