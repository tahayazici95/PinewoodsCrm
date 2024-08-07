using Microsoft.EntityFrameworkCore;
using PinewoodsCrm.API.Data;
using PinewoodsCrm.API.Exceptions;
using PinewoodsCrm.API.Models;

namespace PinewoodsCrm.API.Services;

public class CustomersService(CrmContext db) : ICustomersService
{
    public async Task<List<Customer>> GetCustomers() => await db.Customers.ToListAsync();

    public async Task<Customer> GetCustomer(Guid id) => await db.Customers.FirstOrDefaultAsync(customer => customer.Id == id) ?? throw new CustomerNotFoundException(id);

    public async Task<Customer> CreateCustomer(Customer customer)
    {
        await db.Customers.AddAsync(customer);

        await db.SaveChangesAsync();

        return customer;
    }

    public async Task<Customer> UpdateCustomer(Guid id, Customer customer)
    {
        var existingCustomer = await GetCustomer(id);

        existingCustomer.UpdateDetails(customer);

        await db.SaveChangesAsync();

        return existingCustomer;
    }

    public async Task DeleteCustomer(Guid id)
    {
        var customer = await GetCustomer(id);

        db.Remove(customer);

        await db.SaveChangesAsync();
    }
}
