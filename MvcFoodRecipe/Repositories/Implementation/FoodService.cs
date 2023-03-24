using MvcFoodRecipe.Models.Domain;
using MvcFoodRecipe.Models.DTO;
using MvcFoodRecipe.Repositories.Interface;

namespace MvcFoodRecipe.Repositories.Implementation
{
    public class FoodService : IFoodService
    {
        private readonly DatabaseContext ctx;
        public FoodService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(FoodItem model)
        {
            try
            {


                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;

                ctx.FoodItem.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
        public FoodItem GetById(int id)
        {
            return ctx.FoodItem.Find(id);
        }
    
        public IEnumerable<FoodItem> List(string term = "", bool paging = false, int currentPage = 0)
        {

           // var data = new Enumerable<FoodItem>;
           List<FoodItem> foodList = ctx.FoodItem.ToList();

            //  var list = ctx.FoodItem.ToList();


            //if (!string.IsNullOrEmpty(term))
            //{
            //    term = term.ToLower();
            //    list = list.Where(a => a.Title.ToLower().StartsWith(term)).ToList();
            //}

            //if (paging)
            //{
            //    // here we will apply paging
            //    int pageSize = 5;
            //    int count = list.Count;
            //    int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            //    list = list.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            //    //data.PageSize = pageSize;
            //    //data.CurrentPage = currentPage;
            //    //data.TotalPages = TotalPages;
            //}


            // data.FoodList = list.AsEnumerable();
            return foodList;
        }

        public bool Update(FoodItem model)
        {
            try
            {
                // these genreIds are not selected by users and still present is movieGenre table corresponding to
                // this foodId. So these ids should be removed.
                ctx.FoodItem.Update(model);
                // we have to add these genre ids in movieGenre table
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        

    }
}
