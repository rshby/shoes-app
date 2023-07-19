using shoes_app.Models.DTO;
using shoes_app.Services;

namespace shoes_app.GraphQL
{
   public class ShoesMutation
   {
      // handler insert new data shoes
      [GraphQLName("shoe")]
      public async Task<ShoesResponse?> InsertAsync([Service] IShoesService shoesService, InsertShoesRequest? request)
      {
         return await shoesService.InsertAsync(request);
      }
   }
}
