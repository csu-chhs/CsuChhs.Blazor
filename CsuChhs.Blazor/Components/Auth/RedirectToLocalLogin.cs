using Microsoft.AspNetCore.Components;

namespace CsuChhs.Blazor.Components.Auth
{
    public class RedirectToLocalLogin : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            NavigationManager.NavigateTo("Identity/Account/Login", true);
        }
    }
}
