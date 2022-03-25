using Microsoft.AspNetCore.Components;
using University.API.Models;
using University.Frontend.Data;

namespace University.Frontend.Pages
{
    public class AddressDetailsBase: ComponentBase
    {
        public static Address address { get; set; } = new Address();
        public List<Address> addresses { get; set; } = new List<Address>();

        [Inject]
        public AddressService addressService { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //address = await addressService.GetDataById(Id);
            addresses = await addressService.DeleteData(Id);
        }
    }
}
