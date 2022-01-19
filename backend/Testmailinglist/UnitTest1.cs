using mailinlistapi;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Testmailinglist
{
    public class Tests
    {
    IRepository repository { get; set; }
        [SetUp]
        public void Setup()
        {
      repository = new InMemoryDb();
        }

        [Test, Order(0)]
        public async Task AddUsers()
        {
    await   repository.AddAsync(new User { Name = "Juan", LastName = "X", Email = "email@gmail.com" });
      await repository.AddAsync(new User { Name = "JuanA", LastName = "A", Email = "email1@gmail.com" });
      await
            repository.AddAsync(new User { Name = "JuanB", LastName = "B", Email = "email2@gmail.com" });

      await repository.AddAsync(new User { Name = "JuanC", LastName = "C", Email = "email3@gmail.com" });
      await repository.AddAsync(new User { Name = "JuanAA", LastName = "AA", Email = "email4@gmail.com" });

      await repository.AddAsync(new User { Name = "JuanBB", LastName = "BB", Email = "email5@gmail.com" });

      await repository.AddAsync(new User { Name = "JuanCC", LastName = "CC", Email = "email6@gmail.com" });
      var response= await  repository.GetAllAsync("AA");
      Assert.AreEqual(1, response.Count);
      
        }
    [Test, Order(1)]
    public async Task Search()
    {

      var response =await repository.GetAllAsync("A");
      Assert.AreEqual(2, response.Count);

    }
  }
}
