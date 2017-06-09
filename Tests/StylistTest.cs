using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  [Collection("HairSalon")]
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString  = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_IsPersonTheSame()
    {
      Stylist firstStylist = new Stylist("Hilary");
      Sylist secondStylist = new Stylist("Hilary");
      Assert.Equal(firstStylist, secondStylist);
    }

    
  }
}
