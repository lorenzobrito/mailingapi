using mailinlistapi;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Testmailinglist
{

  public class CosmodbTEST
  {
    IRepository repository { get; set; }
    [SetUp]
    public void Setup()
    {
      repository = CosmoService.InitializeCosmosClientInstanceAsync();
    }

    [Test, Order(0)]
    public  async Task AddUsers()
    {
  await  repository.AddAsync(new User { Name = "JuanA", LastName = "A", Email = "email1@gmail.com" }).ConfigureAwait(true);

      await repository.AddAsync(new User { Name = "JuanAA", LastName = "AA", Email = "email4@gmail.com" });
    
      var response = await repository.GetAllAsync("AA");
  
   
      Assert.AreEqual(1, response.Count);

    }
    [Test, Order(1)]
    public async Task Search()
    {

      var response=await repository.GetAllAsync("A");
      Assert.AreEqual(2, response.Count);

    }
    [Test, Order(2)]
    public async Task Delete()
    {

      var responseApi =await repository.GetAllAsync("A");
      foreach (var item in responseApi)
      {
      await  repository.DeleteItemAsync(item.Email);
      }
      var response =await repository.GetAllAsync("A");
      Assert.AreEqual(0, response.Count);

    }
  }
}
