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
    public StylistTest()
    {
      DBConfiguration.ConnectionString  = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_IsClientTheSame()
    {
      Client firstClient = new Client("David");
      Client secondClient = new Client("David");

      Assert.Equal(firstClient, secondClient);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
