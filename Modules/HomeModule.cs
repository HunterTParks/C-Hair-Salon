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
    }
  }
}
