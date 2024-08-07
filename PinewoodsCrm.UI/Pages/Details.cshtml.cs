using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PinewoodsCrm.API.Models;
using PinewoodsCrm.UI.Services;

namespace PinewoodsCrm.UI.Pages;

public class DetailsModel(ICustomersService service) : PageModel
{
    public Customer Customer { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id is null) return NotFound();

        var customer = await service.GetCustomer(id.Value);

        if (customer is null) return NotFound();

        Customer = customer;

        return Page();
    }
}
