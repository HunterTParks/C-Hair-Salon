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

      // List<Client> newClient = Client.Find(fakeClient.GetId());
      List<Client> listOfClient = Client.GetAll();
      string test = listOfClient[0].GetName();

      Assert.Equal("David", test);
    }

    [Fact]
    public void Test_ChangeNameOfClient()
    {
      Client newClient = new Client("David", 1);
      newClient.SetName("Patrick");
      newClient.Save();

      Assert.Equal("Patrick", newClient.GetName());
    }
    [Fact]
    public void Test_ChangeNameOfClientALTERNATE()
    {
      Client newClient = new Client("David", 1);
      newClient.Save();

      Client fakeClient = Client.Find(newClient.GetId())[0].ChangeName("Mason");
      Assert.Equal("Mason", fakeClient.GetName());
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
