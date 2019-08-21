using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectRepoFrontEnd.Models;
using ProjectRepoFrontEnd.Utility;

namespace ProjectRepoFrontEnd.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetList()
        {
            IEnumerable<ListViewModel> listViews = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = Constants.apiURI;

                var responseTask = client.GetAsync("ListItems");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ListViewModel>>();

                    readTask.Wait();

                    listViews = readTask.Result;
                }
                else
                {
                    listViews = Enumerable.Empty<ListViewModel>();
                    var reason = result.ReasonPhrase;
                    ModelState.AddModelError(string.Empty, reason);
                }
            }

            return View(listViews);
        }


        public IActionResult GetItem(int id)
        {
            ListViewModel listView = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = Constants.apiURI;
                var responseTask = client.GetAsync("ListItems/" + id);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ListViewModel>();

                    readTask.Wait();

                    listView = readTask.Result;
                }
                else
                {

                    var reason = result.ReasonPhrase;
                    listView = new ListViewModel() { id = 0, item = reason };
                    ModelState.AddModelError(string.Empty,reason);
                }
            }

            return View(listView);
        }


    
        }

        
    }

