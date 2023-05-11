using DECommerce.Models;
using DECommerce.Repository;
using IDECommerce.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace DynamicECommerce.Handlers
{
    //public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    //{
    //    private readonly DECommerceDb _context;

    //    public BasicAuthenticationHandler(
    //        IOptionsMonitor<AuthenticationSchemeOptions> options,
    //        ILoggerFactory logger,
    //        UrlEncoder encoder,
    //        ISystemClock clock,
    //        DECommerceDb context) 
    //        : base(options, logger, encoder, clock)
    //        {
    //            _context = context;
    //        }
    //    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    //    {
    //        if (!Request.Headers.ContainsKey("Authorization")) { }
    //        return AuthenticateResult.Fail("Authorization header was not found");

    //        try
    //        {
    //            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
    //            var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
    //            string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
    //            string username = credentials[0];
    //            string password = credentials[1];

    //            Users user = _context.Users.Where(user => user.Username == username && user.Password == password).FirstOrDefault();

    //            if (user == null)
    //                AuthenticateResult.Fail("Invalid username or password");
    //            else
    //            {
    //                var claims = new[] { new Claim(ClaimTypes.Name, user.Username) };
    //                var identity = new ClaimsIdentity(claims, Scheme.Name);
    //                var principal = new ClaimsPrincipal(identity);
    //                var ticket = new AuthenticationTicket(principal, Scheme.Name);

    //                return AuthenticateResult.Success(ticket);
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            return AuthenticateResult.Fail("Error has occurred");
    //        }
    //        return AuthenticateResult.Fail("Authorization headers was not found");
    //    }
    //}
}
