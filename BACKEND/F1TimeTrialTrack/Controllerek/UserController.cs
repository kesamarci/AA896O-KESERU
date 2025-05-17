using F1TimeTrialTrack.Data;
using F1TimeTrialTrack.Entities.Dtos.User;
using F1TimeTrialTrack.Logic.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace F1TimeTrialTrack.Controllerek
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserManager<AppUser> userManager;
        RoleManager<IdentityRole> roleManager;
        DtoProvider dtoProvider;

        public UserController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, DtoProvider dtoProvider)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.dtoProvider = dtoProvider;
        }

        [HttpGet("Admin+/{userid}")]
        [Authorize(Roles = "Admin")]
        public async Task GetAdmin(string userid)
        {
            var user = await userManager.FindByIdAsync(userid);
            if (user == null)
            {
               throw new ArgumentException("Felhasználó nem található");
            }
            else
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
           
        }

        [HttpGet("Admin-/{userid}")]
        [Authorize(Roles = "Admin")]
        public async Task RemoveAdmin(string userid)
        {
            var user = await userManager.FindByIdAsync(userid);
            if (user == null)
            {
                throw new ArgumentException("Felhasználó nem található");
            }
            else
            {
                await userManager.RemoveFromRoleAsync(user, "Admin");
            }
        }

        [HttpGet]
        public IEnumerable<UserViewDto> GetUsers()
        {
            return userManager.Users
                .Select(x => dtoProvider.Mapper.Map<UserViewDto>(x));
        }
        [HttpPost("regisztrálás")]

        public async Task Register(UserInputDto dto)
        {
            var user = new AppUser(dto.UserName);
            user.FirstName=dto.FirstName;
            user.LastName = dto.LastName;
            await userManager.CreateAsync(user, dto.Password);
            if (userManager.Users.Count()==1)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await userManager.AddToRoleAsync(user, "Admin");

            }
        }
        [HttpPost("bejelentkezés")]
        public async Task<IActionResult> Login(UserInputDto dto)
        {
            var user = await userManager.FindByNameAsync(dto.UserName);
            if (user == null)
            {
                throw new ArgumentException("Felhasználó nem található");
            }
            else
            {
                var result = await userManager.CheckPasswordAsync(user, dto.Password);
                if (!result)
                {
                    throw new ArgumentException("Nemjó jelszó!");
                }
                else
                {
                    
                    var claim = new List<Claim>();
                    claim.Add(new Claim(ClaimTypes.Name, user.UserName!));
                    claim.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

                    foreach (var role in await userManager.GetRolesAsync(user))
                    {
                        claim.Add(new Claim(ClaimTypes.Role, role));
                    }

                    int expiryInMinutes = 24 * 60;
                    var token = GenerateAccessToken(claim, expiryInMinutes);

                    return Ok(new LoginTokenDto()
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = DateTime.Now.AddMinutes(expiryInMinutes)
                    });

                }
            }
        }
        private JwtSecurityToken GenerateAccessToken(IEnumerable<Claim>? claims, int expiryInMinutes)//JasonWebToken
        {
            var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes("nagyontitkoskulcsdeténylegagyfasztiskaptamtőlenagyontitkoskulcsdeténylegagyfasztiskaptamtőle"));

            return new JwtSecurityToken(
                  issuer: "F1TTT.com",
                  audience: "F1TTT.com",
                  claims: claims?.ToArray(),
                  expires: DateTime.Now.AddMinutes(expiryInMinutes),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );
        }
    }
}
