using PinewoodsCrm.API.Models;

namespace PinewoodsCrm.UI.Services;

public class CustomersService(HttpClient httpClient) : ICustomersService
{
    private readonly string url = "customers";

    public async Task<List<Customer>> GetCustomers() => await httpClient.GetFromJsonAsync<List<Customer>>(url) ?? [];

    public async Task<Customer?> GetCustomer(Guid id) => await httpClient.GetFromJsonAsync<Customer>($"{url}/{id}");

    public async Task CreateCustomer(Customer customer) => await httpClient.PostAsJsonAsync(url, customer);

    public async Task UpdateCustomer(Guid id, Customer customer) => await httpClient.PutAsJsonAsync($"{url}/{id}", customer);

    public async Task DeleteCustomer(Guid id) => await httpClient.DeleteAsync($"{url}/{id}");
}
