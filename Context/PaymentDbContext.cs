using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI.Context
{
    public class PaymentDbContext : DbContext
    {
        //constractor

        public PaymentDbContext(DbContextOptions options) : base(options)
        {
        }

        // creating table in database
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
    }

}
