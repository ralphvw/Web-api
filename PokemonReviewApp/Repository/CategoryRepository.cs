using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _dataContext;

    public CategoryRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public bool CategoryExists(int id)
    {
        return _dataContext.Categories.Any(c => c.Id == id);
    }

    public ICollection<Category> GetCategories()
    {
        return _dataContext.Categories.OrderBy(c => c.Id).ToList();
    }

    public Category GetCategory(int id)
    {
        return _dataContext.Categories.Where(p => p.Id == id).FirstOrDefault();
    }

    public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
    {
        return _dataContext.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
    }
}