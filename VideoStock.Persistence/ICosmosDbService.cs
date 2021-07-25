using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStock.Domain;

namespace VideoStock.Persistence
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Content>> GetMultipleAsync(string query);
        Task<Content> GetAsync(string id);
        Task AddAsync(Content item);
        Task UpdateAsync(string id, Content item);
        Task DeleteAsync(string id);
    }
}