using System.Linq;

namespace mailinlistapi
{
  public class InMemoryDb : IRepository
  {
   static List<User> _users;
     List<User> Users { get
      {
        if (_users ==null) _users= new List<User>();
        return _users;
      } }


    public List<User> GetAll(string LastName, string Sort="Asc")
    {
      var resultados= new List<User>();
      if (!string.IsNullOrEmpty(LastName))
      {
        resultados=Users.Where(t=>t.LastName.Contains(LastName)).ToList();
      }else resultados=Users;
      return SortList(resultados, Sort);
    }

    Func<User, string> Order = (User user) => user.LastName;
    List<User> SortList(List<User> lista, string Sort)
    {
      var sort = new Sort();
      var result = new List<User>();
      if(Sort.Equals("Asc",StringComparison.CurrentCultureIgnoreCase))
        result = lista.OrderBy(Order).ToList();
      result= lista.OrderByDescending(Order).ToList();
       result.Sort(sort);
      return result;
    }

    public Task AddAsync(User user)
    {
    return  Task.Run(() => Users.Add(user)); ;
    }

    public Task<List<User>> GetAllAsync(string LastName, string Sort = "Asc")
    {
      return Task.Run(() => GetAll(LastName, Sort));
    }

    public Task DeleteItemAsync(string id)
    {
      throw new NotImplementedException();
    }
  }
}
