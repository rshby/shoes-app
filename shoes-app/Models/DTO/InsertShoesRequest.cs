using System.ComponentModel.DataAnnotations;

namespace shoes_app.Models.DTO
{
   [GraphQLName("shoes_request")]
   public class InsertShoesRequest
   {
      [Required]
      [GraphQLName("brand")]
      [GraphQLNonNullType]
      [StringLength(255, MinimumLength = 1)]
      public string? Brand { get; set; }

      [Required]
      [GraphQLName("name")]
      [GraphQLNonNullType]
      [StringLength(255)]
      public string? Name { get; set; }

      [GraphQLName("year_production")]
      public string? YearProduction { get; set; }

      [Required]
      [GraphQLName("price")]
      [GraphQLNonNullType]
      public int? Price { get; set; }
   }
}
