using Microsoft.EntityFrameworkCore;
using PinewoodsCrm.API.Models;

namespace PinewoodsCrm.API.Data;

public class CrmContext(DbContextOptions<CrmContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; } = default!;
}
