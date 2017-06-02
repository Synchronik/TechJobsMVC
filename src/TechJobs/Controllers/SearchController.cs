using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;

            if (searchType != "all")
            {
                List<Dictionary<string, string>> jobba = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobba;
            }
            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobs;
                ViewBag.check = searchType;
            }

            return View("Index");
        }
        // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
