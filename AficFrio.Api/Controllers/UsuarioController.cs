using AficFrio.Api.Bases;
using AficFrio.Api.Repositories;
using AficFrio.Api.Utils;
using AficFrio.Shared.Constants;
using AficFrio.Shared.Dtos;
using AficFrio.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AficFrio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : CustomController
    {
        public readonly UsuarioRepository _usuarioRepository;
        private readonly TransactionService _transactionService;
        private readonly IHubContext<HubSignalR> _hubContext;

        public UsuarioController(IHttpContextAccessor httpContextAccessor,
                                        UsuarioRepository usuarioRepository,
                                        TransactionService transactionService,
                                        InfoToken infoToken,
                                        IHubContext<HubSignalR> hubContext) : base(httpContextAccessor, infoToken)
        {
            _usuarioRepository = usuarioRepository;
            _transactionService = transactionService;
            _hubContext = hubContext;
        }


        [HttpGet("testeSignalR")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUserAndCompanyTAsync([FromQuery] string texto)
        {
            await _hubContext.Clients.All.SendAsync("teste", texto);
            return Ok();
        }

        [HttpGet(UsuarioApi.Autenticar)]
        [AllowAnonymous]
        public async Task<IActionResult> Autenticar([FromQuery] string username, string password)
        {
            var obj = await _usuarioRepository.Autenticar(username, password);
            return Ok(obj);
        }

        [HttpPost(UsuarioApi.Cadastrar)]
        [RoleAuthorize(Roles.DevAccess)]
        public async Task<IActionResult> Cadastrar([FromBody] Usuario usuarioObj)
        {
            var result = await _transactionService.ExecuteInTransactionAsync(async () =>
            {
                var obj = await _usuarioRepository.Cadastrar(usuarioObj);
                return obj;
            });

            return Ok(result);
        }

        [HttpGet(UsuarioApi.BuscarUsuarios)]
        [RoleAuthorize(Roles.AdminAccess)]
        public async Task<IActionResult> BuscarUsuarios()
        {
            var obj = await _usuarioRepository.BuscarUsuarios();
            return Ok(obj);
        }

        [HttpGet(UsuarioApi.CryptografarString)]
        [AllowAnonymous]
        public async Task<IActionResult> CryptografarString([FromQuery] string senha)
        {
            var obj = await _usuarioRepository.CryptografarString(senha);
            return Ok(obj);
        }

        [HttpGet(UsuarioApi.DescryptografarString)]
        [AllowAnonymous]
        public async Task<IActionResult> DescryptografarString([FromQuery] string senhaCriptografada)
        {
            var obj = await _usuarioRepository.DescryptografarString(senhaCriptografada);
            return Ok(obj);
        }

    }
}
