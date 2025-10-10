using AficFrio.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AficFrio.Api.Bases
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomController : ControllerBase 
    {
        public readonly InfoToken _info;

        public CustomController(IHttpContextAccessor httpContex, InfoToken infoToken)
        {
            _info = infoToken;
        }
    }
}
