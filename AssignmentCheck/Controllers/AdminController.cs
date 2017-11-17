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
    public class AdminController : Controller
    {
        // GET: Admin
        /// <summary>
        /// This action opens the admin page with the assignments listed out
        /// along with links for the valid assignments page along with the invalid
        /// assignments page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<Tuple<int, string>> model = new List<Tuple<int, string>>();
            List<Assignment> assignments = Properties.Settings.Default.Assignments;
            for (int i = 1; i <= assignments.Count; i++)
            {
                model.Add(new Tuple<int, string>(i, assignments[i - 1].Title));
            }
            return View(model);
        }

        //GET: Admin/Valid/1
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Valid(int id)
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
            modifiedResults.RemoveAll(p => p.Item2.AreAllValid == false);
            model.Results = modifiedResults;

            return View("List", model);
        }

        //GET: Admin/InValid/1
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult InValid(int id)
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
            return View("List", model);
        }

        public ActionResult All(int id)
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

            return View("List", model);
        }
    }
}