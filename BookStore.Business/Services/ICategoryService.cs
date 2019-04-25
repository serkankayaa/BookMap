namespace BookStore.Business.Services
{
    public interface ICategoryService
    {
        DtoCategory GetCategory(Guid id);
        List<DtoBook> GetCategories();
        void CategoryAdd(DtoCategory model);
        DtoCategory UpdateCategory(DtoCategory model);
        bool DeleteCategory(Guid id);
        object GetCategoryBooks(Guid id);
    }
}