using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shoes_app.Models.Entity
{
   // representasi tabel shoes
   [Table("shoes")]
   public class Shoes
   {
      [Required]
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      [Column("id", Order = 1)]
      public int? Id { get; set; }

      [Required]
      [Column("brand", Order = 2)]
      [MaxLength(255), MinLength(1)]
      public string? Brand { get; set; }

      [Required]
      [Column("name", Order = 3)]
      [MaxLength(255)]
      public string? Name { get; set; }

      
      [Column("year_production", Order = 4)]

      public DateTime? YearProduction { get; set; }

      [Required]
      [Column("price", Order = 5)]
      public int? Price { get; set; }
   }
}
