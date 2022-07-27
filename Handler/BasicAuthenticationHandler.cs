using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Net.Http.Headers;
using ProductAPI.Models;


namespace ProductAPI.Handler
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        private readonly travellerContext _DBContext;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger,
        UrlEncoder encoder, ISystemClock clock, travellerContext _dBContext) : base(options, logger, encoder, clock)
        {
            _DBContext = _dBContext;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(!Request.Headers.ContainsKey("Authorization"))
            return AuthenticateResult.Fail("No Header Found");

var _headervalue=AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

        }

    }
}