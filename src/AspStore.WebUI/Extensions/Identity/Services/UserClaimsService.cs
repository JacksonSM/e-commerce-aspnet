using AspStore.WebUI.Areas.Identity.Data;
using AspStore.WebUI.Extensions.ExtensionsMethods;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspStore.WebUI.Extensions.Identity.Services
{
    public class UserClaimsService : UserClaimsPrincipalFactory<ApplicationUser,IdentityRole>
    {
        private readonly ApplicationDbContext _context;

        public UserClaimsService(ApplicationDbContext dbContext,
                                 UserManager<ApplicationUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
            _context = dbContext;
        }
        public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);
 
            ((ClaimsIdentity)principal.Identity).AddClaims(new[]
                {
                    new Claim("Apelido", user.Apelido),
                    new Claim("NomeCompleto", user.NomeCompleto),
                    new Claim("Email", user.Email),
                    new Claim("DataNascimento", user.DataNascimento.ToBrazilianDate()),
                    new Claim("CPF", user.CPF)
                });
            return principal;
        }
    }
}
