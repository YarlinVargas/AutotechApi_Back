using AutotechApi.Core.Entities;
using AutotechApi.Core.Entities.Login;

namespace AutotechApi.Core.Interfaces.Auth
{
    public interface IAuthRepository
    {
        Task<ReplyService> Auth(AuthEntitie data);
    }
}
