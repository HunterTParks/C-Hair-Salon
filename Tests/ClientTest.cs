using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  [Collection("HairSalon")]
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString  = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_IsClientTheSame()
    {
      Client firstClient = new Client("David", 1);
      Client secondClient = new Client("David", 1);

      Assert.Equal(firstClient, secondClient);
    }

    [Fact]
    public void Test_DisplayListOfClientsOfAStylist()
    {
      Client newClient = new Client("David", 1);
      newClient.Save();

      List<Client> ListOfClients = Client.GetAll();
      List<Client> DefaultList = new List<Client>{newClient};

      Assert.Equal(ListOfClients, DefaultList);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
