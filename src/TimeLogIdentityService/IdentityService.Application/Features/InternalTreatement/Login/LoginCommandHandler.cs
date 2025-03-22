using IdentityService;
using IdentityService.Application;
using IdentityService.Application.Features;
using IdentityService.Application.Features.InternalTreatement.Login;
using IdentityService.Contracts.Constant;
using IdentityService.Domain.Models.Dbo;

namespace IdentityService.Application.Features.InternalTreatement.Login;

public class LoginCommandHandler(UserManager<ApplicationUser> userManager, IConfiguration configuration) :
    IRequestHandler<LoginCommand, Result<LoginResponse>>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;

    public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        ApplicationUser? user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return Result.Fail(ErrorDetails.InvalidEmail);
        }

        bool hasPassword = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!hasPassword)
        {
            return Result.Fail(ErrorDetails.InvalidPassword);
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

        return Result.Ok(new LoginResponse() { Token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}