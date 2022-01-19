namespace mailinlistapi
{
  public class CosmoService
  {
    public static CosmodbMemory InitializeCosmosClientInstanceAsync(string conn)
    {      
      Microsoft.Azure.Cosmos.CosmosClient client = new Microsoft.Azure.Cosmos.CosmosClient(conn);
      CosmodbMemory cosmosDbService = new CosmodbMemory(client);
      

      return cosmosDbService;
    }
  }
}
