using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Orders.Frontend.Shared
{
    public partial class AuthLinks
    {
        private string photoUser="";
        
        [CascadingParameter]

        private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

        protected override async Task OnParametersSetAsync()
        {
            var authenticationState = await AuthenticationStateTask;
            var isAuthenticated = authenticationState.User.Identity!.IsAuthenticated;
            photoUser = "";

            if (isAuthenticated)
            {
                var claims = authenticationState.User.Claims.ToList();
                var photoClaim = claims.FirstOrDefault(x => x.Type == "Photo");
                if (photoClaim!.Value != "")
                {
                    photoUser = "https://localhost:7225" + photoClaim.Value.Substring(1);
                }
            }            
        }
    }
}