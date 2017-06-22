using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Nancy;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/Stylist"] = _ => {
        List<Stylist> AllStylist = Stylist.GetAll();
        return View["Stylist.cshtml", AllStylist];
      };
      Get["/Stylist/{id}"] = parameters => {
        List<Client> newClients = Client.FindList(parameters.id);
        Client newClient = new Client("FAKE", parameters.id);
        newClients.Add(newClient);
        return View["StylistClients.cshtml", newClients];
      };
      Get["/Stylist/Client/All"] = _ => {
        List<Client> allClients = Client.GetAll();
        return View["AllClients.cshtml", allClients];
      };
      Get["/Stylist/new"] = _ => {
        return View["newStylist.cshtml"];
      };

      Post["/Stylist/Success"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["name"]);
        newStylist.Save();
        return View["Success.cshtml"];
      };

      Get["/Client/new/{id}"] = parameters => {
        List<Client> ClientList = Client.FindList(parameters.id);
        Client newClient = new Client("FAKE", parameters.id);
        ClientList.Add(newClient);
        List<Stylist> allStylist = Stylist.GetAll();
        return View["newClient.cshtml", ClientList];
      };

      Post["/Client/Success"] = _ => {
        Client newClient = new Client(Request.Form["name"], Request.Form["stylist"]);
        newClient.Save();
        return View["Success.cshtml"];
      };

      Delete["/deleted"] = _ => {
        Stylist.DeleteAll();
        List<Stylist> allStylist = Stylist.GetAll();
        return View["Stylist.cshtml", allStylist];
      };

      Delete["/deleted/{id}"] = parameters => {
        Client newClient = Client.Find(parameters.id);
        Client.Find(parameters.id).Delete();
        List<Stylist> allStylist = Stylist.GetAll();
        return View["Stylist.cshtml", allStylist];
      };

      Delete["/clients/deleted"] = _ =>{
        Client.DeleteAll();
        return View["Success.cshtml"];
      };

      Get["/change/{id}"] = parameters => {
        Client newClient = Client.Find(parameters.id);
        return View["change.cshtml", newClient];
      };

      Patch["/change/success/{id}"] = parameters => {
        Client newClient = Client.Find(parameters.id);
        string Name = Request.Form["changeName"];
        newClient.Update(Name);
        // newClient.Save();
        Client TestClient = Client.Find(newClient.GetId());
        Console.WriteLine(TestClient.GetName());
        return View["index.cshtml"];
      };
    }
  }
}
