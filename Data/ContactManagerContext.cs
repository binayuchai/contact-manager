using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using contactmanager.Models;

namespace contactmanager.Data
{
    public class ContactManagerContext : DbContext
    {
        public ContactManagerContext(DbContextOptions<ContactManagerContext> options)
        : base(options)
    {
    }

        public DbSet<Person> Persons { get; set; }
        //public DbSet<Category> Category { get; set; }
        //public DbSet<Address> Address { get; set; }
    }
}