using Microsoft.EntityFrameworkCore;
using shoes_app.Models.Entity;

namespace shoes_app.Data
{
   // context database
   public class ShoesContext : DbContext
   {
      // create constructor
      public ShoesContext(DbContextOptions<ShoesContext> options) : base(options)
      {

      }

      // list table database
      public virtual DbSet<Shoes> Shoes { get; set; }
   }
}
