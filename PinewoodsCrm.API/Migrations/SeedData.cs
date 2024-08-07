using Microsoft.EntityFrameworkCore;
using PinewoodsCrm.API.Data;
using PinewoodsCrm.API.Exceptions;
using PinewoodsCrm.API.Models;

namespace PinewoodsCrm.API.Migrations;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new CrmContext(serviceProvider.GetRequiredService<DbContextOptions<CrmContext>>());

        if (context == null || context.Customers == null) throw new NullContextException(nameof(CrmContext));

        if (context.Customers.Any()) return;

        context.Customers.AddRange(
            new Customer
            {
                Name = "Jack Sparrow",
                DateOfBirth = new DateTime(1995, 02, 13),
                Email = "jack.sparrow@pirate.com",
                Address = "Turtle Bay",
                Type = CustomerType.Discount
            },

            new Customer
            {
                Name = "William Turner",
                DateOfBirth = new DateTime(1998, 10, 18),
                Email = "william.turner@pirate.com",
                Address = "Tortuga",
                Type = CustomerType.New
            },

            new Customer
            {
                Name = "Davy Jones",
                DateOfBirth = new DateTime(2003, 04, 28),
                Email = "davy.jones@pirate.com",
                Address = "The Locker",
                Type = CustomerType.Loyal
            }
        );

        context.SaveChanges();
    }
}
