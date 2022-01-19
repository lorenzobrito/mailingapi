using Newtonsoft.Json;
namespace mailinlistapi
{
  public class User
  {
    [JsonProperty(PropertyName = "id")]
    public string Email { get; set; }
    [JsonProperty(PropertyName = "lastname")]
    public string LastName { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string  Name { get; set; }
  }
}
