using shoes_app.Models.DTO;
using shoes_app.Models.Entity;
using shoes_app.Repositories;

namespace shoes_app.Services
{
   public class ShoesService : IShoesService
   {
      // global variable
      private readonly ShoesRepository _shoesRepo;

      // create constructor
      public ShoesService(ShoesRepository shoeRepo)
      {
         this._shoesRepo = shoeRepo;
      }

      // method to get all data shoes
      public async Task<List<ShoesResponse>?> GetAllAsync()
      {
         try
         {
            List<Shoes>? shoes = await _shoesRepo.GetAllAsync();
            if (shoes == null || shoes.Count == 0)
            {
               throw new GraphQLException(new ErrorBuilder().SetMessage("record not found").Build());
            }

            // success get all shoes
            List<ShoesResponse>? responses = shoes.Select(x => new ShoesResponse()
            {
               Id = x.Id,
               Brand = x.Brand,
               Name = x.Name,
               YearProduction = (x.YearProduction != null) ? ((DateTime)x.YearProduction).ToString("yyyy-MM-dd") : null,
               Price = x.Price,
            }).ToList();

            return responses;
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method to get data shoes by id
      public async Task<ShoesResponse?> GetByIdAsync(int id)
      {
         try
         {
            // call procedure in repository
            Shoes? shoe = await _shoesRepo.GetByIdAsync(id);

            // mapping to DTO
            ShoesResponse? response = new ShoesResponse()
            {
               Id = shoe?.Id,
               Brand = shoe?.Brand,
               Name = shoe?.Name,
               YearProduction = (shoe?.YearProduction != null) ? ((DateTime)shoe.YearProduction).ToString("yyyy-MM-dd") : null,
               Price = shoe?.Price,
            };

            return response;
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      public async Task<ShoesResponse?> InsertAsync(InsertShoesRequest? request)
      {
         try
         {
            // create entity
            Shoes? shoe = new Shoes()
            {
               Brand = request?.Brand,
               Name = request?.Name,
               YearProduction = (request?.YearProduction != null) ? DateTime.ParseExact($"{request?.YearProduction} 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) : null,
               Price = request?.Price,
            };

            // call procedure insert in repository
            Shoes? insertedShoe = await _shoesRepo.InsertAsync(shoe);

            // mapping to DTO
            ShoesResponse? response = new ShoesResponse()
            {
               Id = insertedShoe?.Id,
               Brand = insertedShoe?.Brand,
               Name = insertedShoe?.Name,
               YearProduction = (insertedShoe?.YearProduction != null) ? ((DateTime)insertedShoe.YearProduction).ToString("yyyy-MM-dd") : null,
               Price = insertedShoe?.Price,
            };

            return response;
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
