namespace mailinlistapi
{
  public interface IRepository
  {
    Task AddAsync(User user);
    Task<List<User>> GetAllAsync(string LastName,string Sort="Asc");
    Task DeleteItemAsync(string id);



  }
}
