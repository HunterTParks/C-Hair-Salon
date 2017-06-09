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
        Console.WriteLine(Client.Find(parameters.id));
        List<Client> newClients = Client.FindList(parameters.id);
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
        List<Client> newClient = Client.FindList(parameters.id);
        List<Stylist> allStylist = Stylist.GetAll();
        return View["newClient.cshtml", newClient];
      };

      Post["/Client/Success"] = _ => {
        Client newClient = new Client(Request.Form["name"], Request.Form["stylist"]);
        newClient.Save();
        return View["Success.cshtml"];
      };

      Post["/deleted"] = parameters => {
        Client.DeleteAll();
        List<Stylist> allStylist = Stylist.GetAll();
        return View["Stylist.cshtml", allStylist];
      };
    }
  }
}
