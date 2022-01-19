using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
namespace mailinlistapi
{
  public class CosmodbMemory : IRepository
  {
    private Container _container;
    public CosmodbMemory(CosmosClient dbClient)
    {
      this._container = dbClient.GetContainer( "Userdb", "Usercontainer");
    }



    public async Task AddAsync(User user)
    {
        var result = await this._container.CreateItemAsync<User>(user, new PartitionKey(user.Email));
    

    }

    public async Task DeleteItemAsync(string id)
    {
      await this._container.DeleteItemAsync<User>(id, new PartitionKey(id));
    }

    public async Task<List<User>> GetAllAsync(string LastName, string Sort = "Asc")
    {
      var queryString = $"SELECT * FROM c WHERE CONTAINS(c.lastname, \"{LastName}\")";
      var query = this._container.GetItemQueryIterator<User>(new QueryDefinition(queryString));
      List<User> results = new List<User>();
      while (query.HasMoreResults)
      {
        var response = await query.ReadNextAsync();

        results.AddRange(response.ToList());
      }
      results.Sort(new Sort());
      return results;
    }



    public void Add(User user)
    {
      throw new NotImplementedException();
    }
    public List<User> GetAll(string LastName, string Sort = "Asc")
    {
      throw new NotImplementedException();
    }
  }
}
