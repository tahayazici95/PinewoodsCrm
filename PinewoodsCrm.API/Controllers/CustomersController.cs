using Microsoft.AspNetCore.Mvc;
using PinewoodsCrm.API.Exceptions;
using PinewoodsCrm.API.Models;
using PinewoodsCrm.API.Services;

namespace PinewoodsCrm.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController(ICustomersService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get() => Ok(await service.GetCustomers());

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await service.GetCustomer(id));
            }
            catch (CustomerNotFoundException ex)
            {
                return new CustomerNotFoundResult(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Customer customer)
        {
            try
            {
                return Ok(await service.CreateCustomer(customer));
            }
            catch (CustomerNotFoundException ex)
            {
                return new CustomerNotFoundResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Customer customer)
        {
            try
            {
                return Ok(await service.UpdateCustomer(id, customer));
            }
            catch (CustomerNotFoundException ex)
            {
                return new CustomerNotFoundResult(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await service.DeleteCustomer(id);

                return Ok();
            }
            catch (CustomerNotFoundException ex)
            {
                return new CustomerNotFoundResult(ex);
            }
        }
    }
}
