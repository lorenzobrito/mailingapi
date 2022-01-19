using System.Diagnostics.CodeAnalysis;

namespace mailinlistapi
{
  public class Sort : IComparer<User>
  {
    public int Compare(User? x, User? y)
    {
      if (x.LastName == y.LastName)
        return x.Name.CompareTo(y.Name);
      return x.LastName.CompareTo(y.LastName);
    }

    public bool Equals(User? x, User? y)
    {
      if (x.LastName == y.LastName)
        return x.Name.Equals(y.Name);
      return x.LastName.Equals(y.LastName);
    }

    public int GetHashCode([DisallowNull] User obj)
    {
     return obj.Email.GetHashCode();
    }
  }
}
