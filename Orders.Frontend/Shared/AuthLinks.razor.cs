using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Xml.Linq;

namespace Orders.Frontend.Shared
{
    public partial class AuthLinks
    {
        private string? photoUser;
        [CascadingParameter]

        private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

        protected override async Task OnParametersSetAsync()
        {
            var authenticationState = await AuthenticationStateTask;
            var claims = authenticationState.User.Claims.ToList();
            var photoClaim = claims.FirstOrDefault(x => x.Type == "Photo");
            if(photoClaim != null)
            {
                photoUser= "https://localhost:7225" + photoClaim.Value.Substring(1);
            }
        }
    }
}