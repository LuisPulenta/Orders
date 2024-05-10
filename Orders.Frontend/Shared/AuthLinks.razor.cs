using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Orders.Frontend.Pages.Auth;

namespace Orders.Frontend.Shared
{
    public partial class AuthLinks
    {
        private string photoUser="";
        
        private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

        [CascadingParameter] IModalService Modal { get; set; } = default!;

        //----------------------------------------------------------------------------------------
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

        //----------------------------------------------------------------------------------------
        private void ShowModal()
        {
            Modal.Show<Login>();
        }

    }
}