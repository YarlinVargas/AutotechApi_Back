using AutotechApi.Core.Entities;
using AutotechApi.Core.Entities.Login;
using AutotechApi.Core.Interfaces.Auth;
using AutotechApi.Core.Logic.Helper;
using AutotechApi.Core.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace AutotechApi.Infraestructure.Repositories.Auth
{
    public class AuthRepository: IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        ReplyService r = new ReplyService();
        private readonly AppSettings _appSettings;
        public Connection conn;

        public AuthRepository(IConfiguration configuration, IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _appSettings = appSettings.Value;
            _httpContextAccessor = httpContextAccessor;
            conn = new Connection();
        }

        #region Autenticación
        public async Task<ReplyService> Auth(AuthEntitie data)
        {
            using (SqlConnection connection = conn.ConnectBD(_configuration))
            {
                await connection.OpenAsync();

                var sentenciaU = $"SELECT * FROM [AUTOTECHDB].[dbo].[Usuario] where userName={data.UserName}";

                SqlCommand cmd = new SqlCommand(sentenciaU, connection);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sqldr = await cmd.ExecuteReaderAsync();

                Dictionary<string, object> userData = new Dictionary<string, object>();

                bool passwordValidate = false;
                int db = 1;
                int idUser = 0;
                string encript = "";
                string message = "";

                if (sqldr.HasRows)
                {
                    while (await sqldr.ReadAsync())
                    {
                        message = "El usuario ya existe";
                    }

                    await sqldr.CloseAsync();
                }
                //    idUser = cmd.Parameters["@IdUser"].Value != null ? (int)cmd.Parameters["@IdUser"].Value : 0;
                //    encript = cmd.Parameters["@EncryptedUser"].Value.ToString();

                //    r.Message = cmd.Parameters["@Message"].Value.ToString();
                //    r.Flag = (bool)cmd.Parameters["@Flag"].Value;
                //    r.Status = 200;

                //    if (r.Flag)
                //    {
                //        if (passwordValidate) //Contraseña correcta
                //        {
                //            string role = data.LoginType == 1 ? "Usuario" : data.LoginType == 2 ? "Empresa" : "Paciente";
                //            //Llamar servicio para generar el token de acceso
                //            string token = JwtToken.GenerateTokenJwt(data.UserName, idUser, role, _appSettings);
                //            string refreshToken = JwtToken.GenerateRefreshTokenJwt();

                //            Dictionary<string, object> rtaAuth = new Dictionary<string, object>();
                //            rtaAuth.Add("token", token);
                //            rtaAuth.Add("refreshToken", refreshToken);
                //            rtaAuth.Add("redirect", data.LoginType == 1 ? "gestionUsuario" : data.LoginType == 2 ? "welcomeCompany" : "welcomePatient");

                //            //Llamar servicio para actualizar la fecha de inicio de sesión

                //            if (data.LoginType == 3)
                //            {
                //                await UpdatePatientSessionDate(idUser, db, tenantInfo.Name);
                //            }
                //            else
                //            {
                //                await UpdateSessionDate(idUser, connection);
                //            }

                //            r.Data = rtaAuth;
                //            r.Message = "Autenticación correcta";
                //            r.Status = 200;

                //            return r;
                //        }
                //    }

                //    if (r.Message == "First time session" && passwordValidate) //Inicio de sesión por primera vez
                //    {

                //        Dictionary<string, object> rtaAuth = new Dictionary<string, object>();
                //        rtaAuth.Add("IdUser", idUser);
                //        rtaAuth.Add("token", encript);

                //        r.Data = rtaAuth;
                //        r.Message = "Autenticación por primera vez";
                //        return r;
                //    }
                //}

                //if (r.Message == "User password expired")
                //{

                //    Dictionary<string, object> rtaAuth = new Dictionary<string, object>();
                //    userData.Add("IdUser", idUser);
                //    userData.Add("token", encript);
                //    r.Data = rtaAuth;
                //}



                r.Message = "El usuario o contraseña no coinciden, valide sus credenciales e intente de nuevo.";
                r.Flag = false;
                r.Status = 400;
                return r;
            }
        }
        #endregion

    }
}
