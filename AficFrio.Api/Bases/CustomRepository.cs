using AficFrio.Shared.Dtos;
using Microsoft.AspNetCore.Http;

namespace AficFrio.Api.Bases
{
    public class CustomRepository
    {
        public readonly InfoToken _info;

        public CustomRepository(IHttpContextAccessor httpContextAccessor, InfoToken infoToken)
        {
            _info = infoToken;
        }

    }
}