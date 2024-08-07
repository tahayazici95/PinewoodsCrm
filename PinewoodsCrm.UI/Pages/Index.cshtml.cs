using Microsoft.AspNetCore.Mvc.RazorPages;
using PinewoodsCrm.API.Models;
using PinewoodsCrm.UI.Services;

namespace PinewoodsCrm.UI.Pages;

public class IndexModel(ICustomersService service) : PageModel
{
    public IList<Customer> Customers { get; set; } = default!;

    public async Task OnGetAsync() => Customers = await service.GetCustomers();
}
