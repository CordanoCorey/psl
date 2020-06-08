using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using psl.Entity.DataClasses;

namespace psl.API.Infrastructure.Authentication
{

    public interface ITokenProviderService
    {
        //Task<LoggedInUserModel> GetLoggedInUser(string email, TokenProviderOptions options);
    }

    public class TokenProviderService : ITokenProviderService
    {
        private readonly IMapper _mapper;

        public TokenProviderService(IMapper mapper)
        {
            _mapper = mapper;
        }

        private async Task<IEnumerable<Claim>> GenerateClaims(string username, int userid, DateTime dt, TokenProviderOptions options)
        {
            // Specifically add the jti (nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:
            var jwtclaims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userid.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, username),
                new Claim(JwtRegisteredClaimNames.Jti, await options.NonceGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(dt).ToString(), ClaimValueTypes.Integer64)
            };

            return jwtclaims;
        }

        /// <summary>
        /// Get this datetime as a Unix epoch timestamp (seconds since Jan 1, 1970, midnight UTC).
        /// </summary>
        /// <param name="date">The date to convert.</param>
        /// <returns>Seconds since Unix epoch.</returns>
        public static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
