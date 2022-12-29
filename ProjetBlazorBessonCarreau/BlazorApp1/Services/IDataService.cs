using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public interface IDataService
    {
        Task Add(ToolModel model);

        Task<int> Count();

        Task<List<Tool>> List(int currentPage, int pageSize);

        Task<Tool> GetById(int id);

        Task Update(int id, ToolModel model);

        Task Delete(int id);
    }
}
