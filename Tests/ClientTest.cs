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
      Client fakeClient = new Client("David", 1);
      fakeClient.Save();

      Client newClient = Client.Find(fakeClient.GetId());
      List<Client> listOfClient = Client.GetAll();
      string test = listOfClient[0].GetName();

      Assert.Equal("David", test);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
