using Gyakorlo.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Gyakorlo.Models
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<Felhasznalo, IdentityRole>
    {
        public CustomClaimsPrincipalFactory(
            UserManager<Felhasznalo> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        { }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Felhasznalo user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            // Add custom claim
            identity.AddClaim(new Claim("Nev", user.Nev ?? ""));

            return identity;
        }
    }
}
