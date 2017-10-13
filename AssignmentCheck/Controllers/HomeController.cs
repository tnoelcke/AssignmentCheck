using AssignmentCheck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentCheck.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Default
        [HttpGet]
        public ActionResult Index()
        {

            string path = AssignmentCheck.Properties.Settings.Default.RootPath;
            List<Assignment> Assignments = AssignmentCheck.Properties.Settings.Default.Assignments;
            AssignmentsResults assignmentResults = new AssignmentsResults();
            string userName = User.Identity.Name;
            char[] seperator = { '\\' };
            userName = userName.Split('\\')[1];
            path += "\\" + userName;
            assignmentResults.UserName = userName;
            foreach(Assignment toCheck in Assignments)
            {
                AssignmentResult Checked = new AssignmentResult();
                Checked.Results = toCheck.CheckCriterion(path);
                Checked.Title = toCheck.Title;
                assignmentResults.Results.Add(Checked);
            }
            //return View("Index", test);
            throw new NotImplementedException();
        }
    }
}