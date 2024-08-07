using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PinewoodsCrm.API.Models;
using PinewoodsCrm.UI.Services;

namespace PinewoodsCrm.UI.Pages
{
    public class EditModel(ICustomersService service) : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id is null) return NotFound();

            var customer =  await service.GetCustomer(id.Value);

            if (customer is null) return NotFound();

            Customer = customer;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                await service.UpdateCustomer(Customer.Id, Customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await service.GetCustomer(Customer.Id) is null) return NotFound();

                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
