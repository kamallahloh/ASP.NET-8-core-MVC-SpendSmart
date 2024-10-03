using Microsoft.EntityFrameworkCore;
using SpendSmart.Models;

namespace SpendSmart.Data
{
    public class SpendSmartDbContext : DbContext // important to inherit it from the EntityFrameworkCore
    {
        // create DataBase Table for our Class Entity
        public DbSet<Expense> Expenses { get; set; } // make it as a property with public get set


        // create constructor
        public SpendSmartDbContext(DbContextOptions<SpendSmartDbContext> options) : base(options) // use the base constructor
        {
            
        }
    }
}
