using shoes_app.Models.DTO;
using shoes_app.Services;

namespace shoes_app.GraphQL
{
   public class ShoesQuery
   {
      // handler to get all data shoes
      [GraphQLName("shoes")]
      public async Task<List<ShoesResponse>?> GetAllAsync([Service] IShoesService shoesService)
      {
         return await shoesService.GetAllAsync();
      }

      // handler to get data shoes by id
      [GraphQLName("shoe")]
      public async Task<ShoesResponse?> GetByIdAsync([Service] IShoesService shoesService, int id)
      {
         return await shoesService.GetByIdAsync(id);
      }
   }
}
