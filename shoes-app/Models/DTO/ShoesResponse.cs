using System.ComponentModel.DataAnnotations;

namespace shoes_app.Models.DTO
{

   [GraphQLName("shoes_response")]
   public class ShoesResponse
   {
      [Required]
      [GraphQLName("id")]
      [GraphQLNonNullType]
      public int? Id { get; set; }

      [Required]
      [GraphQLName("brand")]
      [GraphQLNonNullType]
      public string? Brand { get; set; }

      [Required]
      [GraphQLName("name")]
      [GraphQLNonNullType]
      public string? Name { get; set; }


      [GraphQLName("year_production")]
      public string? YearProduction { get; set; }

      [Required]
      [GraphQLName("price")]
      [GraphQLNonNullType]
      public int? Price { get; set; }
   }
}
