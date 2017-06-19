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
      //DBConfiguration.ConnectionString  = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
      DBConfiguration.ConnectionString = "Data Source=GAMING-PC;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
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
      Client anotherClient = new Client("Sarah", 1);
      fakeClient.Save();
      anotherClient.Save();

      List<Client> newClient = Client.FindList(fakeClient.GetStylistId());
      List<Client> listOfClient = Client.GetAll();

      Assert.Equal(newClient[1].GetName(), listOfClient[1].GetName());
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

      Client fakeClient = Client.FindList(newClient.GetStylistId())[0].ChangeName("Mason");
      Assert.Equal("Mason", fakeClient.GetName());
    }

    [Fact]
    public void Test_FindClientFromStylist()
    {
      Stylist newStylist = new Stylist("Hilary", 1);
      newStylist.Save();
      Client controlClient = new Client("David", 1);
      controlClient.Save();

      Client newClient = Client.Find(1);
      Assert.Equal(controlClient, newClient);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
