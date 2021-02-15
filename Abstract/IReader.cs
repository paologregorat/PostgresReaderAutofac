using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIPostgresReader.Abstract
{
    public interface IReader
    {
        Task<IEnumerable<T>> GetCollectionAsync<T>(string query, object? @params = default);

        Task<int> CommandAsync(string command, object? @params = default);
    }
}