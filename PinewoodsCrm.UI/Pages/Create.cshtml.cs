using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PinewoodsCrm.API.Models;
using PinewoodsCrm.UI.Services;

namespace PinewoodsCrm.UI.Pages
{
    public class CreateModel(ICustomersService service) : PageModel
    {
        public IActionResult OnGet() => Page();

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await service.CreateCustomer(Customer);

            return RedirectToPage("./Index");
        }
    }
}
