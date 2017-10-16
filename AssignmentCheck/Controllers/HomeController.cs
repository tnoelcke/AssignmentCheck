using AssignmentCheck.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssignmentCheck.Extensions;
using AssignmentCheck.Models;

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
    }
}