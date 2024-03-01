using Microsoft.AspNetCore.Components;
using Orders.Frontend.Repositories;
using Orders.Shared.Entities;

namespace Orders.Frontend.Pages.Countries
{
    public partial class CountriesIndex
    {
        [Inject] private IRepository Repository { get; set; } = null!;

        private List<Country>? Countries;

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var responseHttp = await Repository.GetAsync<List<Country>>("api/countries");
            Countries = responseHttp.Response;
        }
    }
}
