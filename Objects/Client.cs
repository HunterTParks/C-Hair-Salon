using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HairSalon
{
  public class Client
  {
    private string _name;
    private int _id;
    private int _stylistId;

    public Client(string Name, int StylistId, int Id = 0)
    {
      _name = Name;
      _id = Id;
      _stylistId = StylistId;
    }
    public void SetName(string Name)
    {
      _name = Name;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public int GetStylistId()
    {
      return _stylistId;
    }

    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetId() == newClient.GetId());
        bool nameEquality = (this.GetName() == newClient.GetName());
        bool stylistIdEquality = (this.GetStylistId() == newClient.GetStylistId());
        return (idEquality && nameEquality && stylistIdEquality);
      }
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, stylist_id) OUTPUT INSERTED.id VALUES (@client, @stylist);", conn);

      SqlParameter ClientParameter = new SqlParameter();
      ClientParameter.ParameterName = "@client";
      ClientParameter.Value = this.GetName();

      SqlParameter StylistIDParameter = new SqlParameter();
      StylistIDParameter.ParameterName = "@stylist";
      StylistIDParameter.Value = this.GetStylistId();

      cmd.Parameters.Add(ClientParameter);
      cmd.Parameters.Add(StylistIDParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        int clientStylistId = rdr. GetInt32(2);
        Client newClient = new Client(clientName, clientStylistId, clientId);
        allClients.Add(newClient);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return allClients;
    }

    public static List<Client> Find(int id)
    {
      List<Client> foundClients = new List<Client>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE stylist_id = @ClientId", conn);

      SqlParameter ClientIdParameter = new SqlParameter();
      ClientIdParameter.ParameterName = "@ClientId";
      ClientIdParameter.Value = id.ToString();
      cmd.Parameters.Add(ClientIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();


      while(rdr.Read())
      {
        int foundClientId = 0;
        string foundClientName = null;
        int foundStylistid = 0;
        foundClientId = rdr.GetInt32(0);
        foundClientName = rdr.GetString(1);
        foundStylistid = rdr.GetInt32(2);
        Client foundClient = new Client(foundClientName, foundStylistid, foundClientId);
        foundClients.Add(foundClient);
      }


      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return foundClients;
    }

    public Client ChangeName(string Name)
    {
      this._name = Name;
      return this;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM clients", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
