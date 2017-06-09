using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HairSalon
{
  public class Client
  {
    private string _name;
    private int _id;

    public Client(string Name, int Id = 0)
    {
      _name = Name;
      _id = Id;
    }

    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
  }
}
