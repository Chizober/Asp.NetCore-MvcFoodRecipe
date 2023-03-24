namespace MvcFoodRecipe.Repositories.Interface;

public interface IFileService
{
    public Tuple<int, string> SaveImage(IFormFile imageFile);
    public bool DeleteImage(string imageFileName);
}
