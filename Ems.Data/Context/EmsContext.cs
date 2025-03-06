using System.Net.Mime;
using Ems.Data.Entities;
using Ems.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ems.Data.Contexts;
public class EMSContext(DbContextOptions<EMSContext> options) : DbContext(options)
{
    public DbSet<InfoCountry> InfoCountries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<InfoContentType> ContentTypes { get; set; }
    public DbSet<InfoContent> InfoContents { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Organization> Organizations { get; set; }
}