namespace Assignment7.Database;
using Microsoft.EntityFrameworkCore;
using Assignment7.Entities;

public class PersonDbContext : DbContext
{
    public PersonDbContext(DbContextOptions<PersonDbContext> options):base(options)
    {

    }
    
    public DbSet<Person> People {get; set;}
}
