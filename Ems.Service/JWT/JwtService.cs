using Ems.Common.Dtos;
using Ems.Common.JwtFile;
using Ems.Data.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Ems.Service.JWT;
public class JwtService
{
    private readonly IConfiguration _configuration;
    private readonly JwtParam _jwtParam;
    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
        _jwtParam = _configuration.GetSection("JwtSettings")
            .Get<JwtParam>()!;
    }

    #region GenerateToken


    public TokenDto GenerateToken(User user, bool populateToken)
    {
        var key = Encoding.UTF32.GetBytes(_jwtParam.Key);
        var signingKey = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.RoleId.ToString())
        };

        var security = new JwtSecurityToken(issuer: _jwtParam.Issuer,
            audience: _jwtParam.Audience,
            signingCredentials: signingKey,
            claims: claims,
            expires: DateTime.Now.AddHours(3));

        var token = new JwtSecurityTokenHandler().WriteToken(security);

        if (populateToken)
        {
            var refreshToken = GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpireDate = DateTime.Now.AddDays(10);
        }
        return new TokenDto(AccessToken: token, RefreshToken: user.RefreshToken!);
    }

    private string GenerateRefreshToken()
    {
        var randomToken = new byte[32];
        var nrg = RandomNumberGenerator.Create();
        nrg.GetBytes(randomToken);

        return Convert.ToBase64String(randomToken);
    }

    #endregion

    public Tuple<bool, string> ValidateToken(string accessToken)
    {
        var key = System.Text.Encoding.UTF32.GetBytes(_jwtParam.Key);
        var options = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = _jwtParam.Issuer,
            ValidateAudience = true,
            ValidAudience = _jwtParam.Audience,
            ValidateLifetime = false,
            ClockSkew = TimeSpan.Zero
        };

        var tokenHandler = new JwtSecurityTokenHandler();


        var principal = tokenHandler.ValidateToken(accessToken, options, out var validatedToken);

        var jwtSecurityToken = validatedToken as JwtSecurityToken;

        var check = jwtSecurityToken is null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        if (check)
        {
            return new Tuple<bool, string>(false, "Invalid token");
        }

        var username = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

        if (string.IsNullOrEmpty(username))
        {
            return new Tuple<bool, string>(false, "Invalid token");
        }

        return new Tuple<bool, string>(true, username);
    }
}
