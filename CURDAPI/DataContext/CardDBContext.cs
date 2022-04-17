using CURDAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CURDAPI.DataContext
{
    public class CardDBContext : DbContext
    {
        public CardDBContext( DbContextOptions options) : base(options)
        {
        }

        // Create a DBSet

        public DbSet<Card> Cards { get; set; }
    }
}
