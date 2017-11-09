using AssignmentCheck.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssignmentCheck.Extensions;
using AssignmentCheck.Models;
using System.IO;

namespace AssignmentCheck.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Default
        [HttpGet]
        public ActionResult Index()
        {
            //gets the root path to the class folder structure
            string path = AssignmentCheck.Properties.Settings.Default.RootPath;
            //gets the configured assignment criteria that do the validation of the folders.
            List<Assignment> assignments = AssignmentCheck.Properties.Settings.Default.Assignments;
            //get the username for the logged in user then add it to the folder path to complete the path to
            //the current logged on user's class folder
            string userName = User.Identity.Name.RemoveDomainFromIdentity();
            path = System.IO.Path.Combine(path, userName);
            //turn the settings into results in the model
            AssignmentResultsViewModel model = new AssignmentResultsViewModel()
            {
                UserName = userName,
                Results = assignments.Select(a => a.Validate(path))
            };

            return View(model);
        }

        //Get: Admin/{id}
        public ActionResult Admin(int id)
        {
            //gets the root path to the class folder structure
            string path = AssignmentCheck.Properties.Settings.Default.RootPath;
            //gets the configured assignment criteria that do the validation of the folders.
            List<Assignment> assignments = AssignmentCheck.Properties.Settings.Default.Assignments;
            Assignment target = null;
            //get the assignment based on the id
            if (id < 1 || id > assignments.Count)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                target = assignments[id - 1];
            }
            string[] paths = Directory.GetDirectories(path);

            //turn the settings into results in the model
            AdminViewModel model = new AdminViewModel()
            {
                Results = paths.Select(p => new Tuple<string, AssignmentResult>(p, target.Validate(p)))
            };

            //by default this view will only return the invalid results.
            //remove the valid results from the list.
            List<Tuple<string, AssignmentResult>> modifiedResults = model.Results.ToList();
            modifiedResults.RemoveAll(p => p.Item2.AreAllValid == true);
            model.Results = modifiedResults;

            return View(model);
        }

        [HttpPost]
        [Route("Home/Admin/{id}/{bool}", Order = 1)]
        public ActionResult Admin(int id, bool showValid)
        {
            //gets the rot path to the class folder structur.
            string path = AssignmentCheck.Properties.Settings.Default.RootPath;
            //get the configured assignment criteria that do the validation of the folders.
            List<Assignment> assignments = AssignmentCheck.Properties.Settings.Default.Assignments;
            Assignment target = null;
            //get the assignment based on the id.
            if(id < 1 || id > assignments.Count)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                target = assignments[id - 1];
            }
            string[] paths = Directory.GetDirectories(path);
            AdminViewModel model;
            //Now lets filter the results if they need to be filtered otherwise just get all the results
            if (showValid)
            {
                model = new AdminViewModel()
                {
                    Results = paths.Select(p => new Tuple<string, AssignmentResult>(p, target.Validate(p)))
                };
            }
            else
            {
                model = new AdminViewModel()
                {
                    Results = paths.Select(p => new Tuple<string, AssignmentResult>(p, target.Validate(p)))
                };
                //remove all valid results.
                List<Tuple<string, AssignmentResult>> modifiedResults = model.Results.ToList();
                modifiedResults.RemoveAll(x => x.Item2.AreAllValid);
                model.Results = modifiedResults;
            }
            return PartialView("Views/partialViews/_AssignmentPartial.cshtml", model);
        }
    }
}