using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using OOEC.Helper;
using OOEC.Models;
using OOECAPI.Models;

namespace OOEC.Controllers
{
    public class HomeController : Controller
    {
        OOEC_API _api = new OOEC_API();
        public async Task<IActionResult> Index()
        {
            List<Team> team = new List<Team>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Team");
            if(res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                team = JsonConvert.DeserializeObject<List<Team>>(result);

            }
            return View(team);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
