using PinewoodsCrm.API.Models;

namespace PinewoodsCrm.API.Services;

public interface ICustomersService
{
    public Task<List<Customer>> GetCustomers();
    public Task<Customer> GetCustomer(Guid id);
    public Task<Customer> CreateCustomer(Customer customer);
    public Task<Customer> UpdateCustomer(Guid id, Customer customer);
    public Task DeleteCustomer(Guid id);
}
