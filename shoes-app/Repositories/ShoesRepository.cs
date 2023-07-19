using Microsoft.EntityFrameworkCore;
using shoes_app.Data;
using shoes_app.Models.Entity;

namespace shoes_app.Repositories
{
   public class ShoesRepository
   {
      // global variable
      private readonly ShoesContext _db;

      // create constructor
      public ShoesRepository(ShoesContext db)
      {
         this._db = db;
      }

      // method to get all data shoes
      public async Task<List<Shoes>?> GetAllAsync()
      {
         try
         {
            return await _db.Shoes.ToListAsync();
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method to get data shoes by id
      public async Task<Shoes?> GetByIdAsync(int? id)
      {
         try
         {
            return await _db.Shoes.FirstAsync(x => x.Id == id);
         }
         catch (Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method to insert new data shoes
      public async Task<Shoes?> InsertAsync(Shoes? newShoes)
      {
         try
         {
            await _db.Shoes.AddAsync(newShoes);
            await _db.SaveChangesAsync();

            return newShoes;
         }
         catch(Exception err)
         {
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
