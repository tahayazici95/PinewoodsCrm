using PinewoodsCrm.API.Models;

namespace PinewoodsCrm.UI.Services;

public interface ICustomersService
{
    public Task<List<Customer>> GetCustomers();
    public Task<Customer?> GetCustomer(Guid id);
    public Task CreateCustomer(Customer customer);
    public Task UpdateCustomer(Guid id, Customer customer);
    public Task DeleteCustomer(Guid id);
}
