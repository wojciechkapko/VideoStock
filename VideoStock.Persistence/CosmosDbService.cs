using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStock.Domain;

namespace VideoStock.Persistence
{
    public class CosmosDbService : ICosmosDbService
    {
        private readonly Container _container;
        public CosmosDbService(
            CosmosClient cosmosDbClient,
            string databaseName,
            string containerName)
        {
            _container = cosmosDbClient.GetContainer(databaseName, containerName);
        }
        public async Task AddAsync(Content item)
        {
            await _container.CreateItemAsync(item, new PartitionKey(item.Id));
        }
        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<Content>(id, new PartitionKey(id));
        }
        public async Task<Content> GetAsync(Guid id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Content>(id.ToString(), new PartitionKey(id.ToString()));
                return response.Resource;
            }
            catch (CosmosException) //For handling item not found and other exceptions
            {
                return null;
            }
        }
        public async Task<IEnumerable<Content>> GetMultipleAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<Content>(new QueryDefinition(queryString));
            var results = new List<Content>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }
        public async Task UpdateAsync(string id, Content item)
        {
            await _container.UpsertItemAsync(item, new PartitionKey(id));
        }
    }
}
