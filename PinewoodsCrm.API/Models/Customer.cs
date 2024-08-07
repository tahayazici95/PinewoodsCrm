using System.ComponentModel.DataAnnotations;

namespace PinewoodsCrm.API.Models;

public class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    [DataType(DataType.Date)]
    public required DateTime DateOfBirth { get; set; }
    public required string Email { get; set; }
    public string? Address { get; set; }
    public CustomerType Type { get; set; } = CustomerType.New;

    public void UpdateDetails(Customer customer)
    {
        Name = customer.Name;
        DateOfBirth = customer.DateOfBirth;
        Email = customer.Email;
        Address = customer.Address;
        Type = customer.Type;
    }
}
