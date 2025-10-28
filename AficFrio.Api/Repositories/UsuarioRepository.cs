using AficFrio.Api.Bases;
using AficFrio.Api.Database.Context;
using AficFrio.Api.Utils;
using AficFrio.Shared.Dtos;
using AficFrio.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AficFrio.Api.Repositories
{
    public class UsuarioRepository : CustomRepository
    {
        public readonly TokenUtils _token;
        public readonly CryptoUtils _cryptoUtils;
        public readonly DBRestaurante _dbRestaurante;

        public UsuarioRepository(IHttpContextAccessor httpContextAccessor,
                                        TokenUtils tokenUtils,
                                        CryptoUtils cryptoUtils,
                                        DBRestaurante dbRestaurante,
                                        InfoToken infoToken) : base(httpContextAccessor, infoToken)
        {
            _token = tokenUtils;
            _cryptoUtils = cryptoUtils;
            _dbRestaurante = dbRestaurante;
        }

        public async Task<Usuario> Cadastrar(Usuario usuarioObj)
        {
            usuarioObj.Senha = _cryptoUtils.EncryptString(usuarioObj.Senha);

            await _dbRestaurante.Usuarios.AddAsync(usuarioObj);
            await _dbRestaurante.SaveChangesAsync();

            return usuarioObj;
        }

        public async Task<string> Autenticar(string username, string password)
        {
            password = _cryptoUtils.EncryptString(password);
            var usuarioObj = await _dbRestaurante.Usuarios.Where(w => EF.Functions.Like(w.Username, username) && w.Senha == password).FirstOrDefaultAsync();

            if (usuarioObj is null)
                throw new Exception("Usuário não encontrado");

            var token = _token.GerarToken(usuarioObj.Id, usuarioObj.EmpresaId, usuarioObj.Username, usuarioObj.Email, usuarioObj.Role, usuarioObj.CadastradoEm);

            return token;
        }

        public async Task<List<UsuarioDto>> BuscarUsuarios()
        {
            var usuarios = await (from users in _dbRestaurante.Usuarios
                                  select new UsuarioDto
                                  {
                                      Id = users.Id,
                                      Username = users.Username,
                                      Email = users.Email,
                                      CadastradoEm = users.CadastradoEm,
                                      Role = users.Role
                                  }).ToListAsync();
            return usuarios;
        }


        public async Task<string> CryptografarString(string senha)
        {
            var senhaCryptografada = _cryptoUtils.EncryptString(senha);
            return senhaCryptografada;
        }

        public async Task<string> DescryptografarString(string senhaCriptografada)
        {
            var senha = _cryptoUtils.DecryptString(senhaCriptografada);
            return senha;
        }

    }
}
