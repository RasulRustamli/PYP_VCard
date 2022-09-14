using Microsoft.EntityFrameworkCore;
using PYP_VCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_VCard.DataContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FHK353D;Database=VCardDb;Integrated Security=True; MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
      

        public DbSet<VCard> VCards { get; set; }

      
    }
}
