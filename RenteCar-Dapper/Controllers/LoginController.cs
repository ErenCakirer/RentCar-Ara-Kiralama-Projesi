using Dapper;
using Microsoft.AspNetCore.Mvc;
using RenteCar_Dapper.Dtos.LoginDtos;
using RenteCar_Dapper.Models.DapperContext;
using RenteCar_Dapper.Tools;

namespace RenteCar_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto loginDto)
        {
            var username = loginDto.Username?.Trim();
            var password = loginDto.Password?.Trim();
            string query = @"SELECT 
                                UserID AS Id, 
                                Username, 
                                CAST(UserRole AS NVARCHAR(50)) AS Role 
                             FROM AppUser 
                             WHERE LTRIM(RTRIM(Username)) = @username 
                               AND LTRIM(RTRIM(Password)) = @password";

            var parameters = new DynamicParameters();
            parameters.Add("@username", username);
            parameters.Add("@password", password);

            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<CheckAppUser>(query, parameters);

                if (user != null)
                {
                    user.IsExist = true;

                    var token = JwtTokenGenerator.GenerateToken(user);
                    return Ok(token);
                }
                else
                {
                    string checkUserQuery = "SELECT Password FROM AppUser WHERE LTRIM(RTRIM(Username)) = @username";
                    var dbPassword = await connection.QueryFirstOrDefaultAsync<string>(checkUserQuery, new { username });

                    if (dbPassword == null)
                    {
                        return BadRequest($"HATA: '{username}' adında bir kullanıcı veritabanında bulunamadı.");
                    }
                    else
                    {
                        return BadRequest($"HATA: Kullanıcı bulundu ancak şifre uyuşmuyor. DB'deki: '{dbPassword.Trim()}', Gönderilen: '{password}'");
                    }
                }
            }
        }
    }
}