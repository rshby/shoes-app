using shoes_app.Models.DTO;

namespace shoes_app.Services
{
   public interface IShoesService
   {
      // method untuk get all data shoes
      public Task<List<ShoesResponse>?> GetAllAsync();

      // method untuk get data shoes by id
      public Task<ShoesResponse?> GetByIdAsync(int id);

      // method untuk add new shoes
      public Task<ShoesResponse?> InsertAsync(InsertShoesRequest? request);
   }
}
