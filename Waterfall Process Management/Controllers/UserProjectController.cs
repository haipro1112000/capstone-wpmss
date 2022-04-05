using DatabaseModels.DataAccessObject;
using DatabaseWPMSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Waterfall_Process_Management.Controllers
{
    public class UserProjectController : Controller
    {
        // 
        [HttpGet]
        public ActionResult RedirectAction(int Project_id)
        {
            ACCOUNT account = (ACCOUNT)Session["user"];
            ROLE_IN_PROJECT role = new UserProjectDAO().FindRoleByAccountIdAndProjectID(account.Acc_ID, Project_id);
            if (role == null)
            {
                Session.Add("error", 1);
                return RedirectToAction("ProjectManage", "Users");
            }
            if (role.Role_ID == 1)
            {
                Session.Remove("error");
                Session.Add("Role_In_Project", role);
                return RedirectToAction("ProjectManageDetail");
            }

            if (role.Role_ID == 2)
            {
                Session.Remove("error");
                Session.Add("Role_In_Project", role);
                return RedirectToAction("Development");
            }

            if (role.Role_ID == 3)
            {
                Session.Remove("error");
                Session.Add("Role_In_Project", role);
                return RedirectToAction("ProjectManageDetail");
            }


            return RedirectToAction("ProjectManage", "Users");
        }


        [HttpGet]
        public ActionResult LogoutProject()
        {
            Session.Remove("Role_In_Project");
            return RedirectToAction("ProjectManage", "Users");
        }


        // POST: UserProject
        [HttpGet]
        public ActionResult ProjectManageDetail()
        {
            if (Session["user"] == null)
            {
                Response.Redirect("https://localhost:44381/Authentication/Login");
            }
            ViewBag.User = Session["user"];

            //Response.Redirect("https://localhost:44381/UserProject/ProjectManageDetail");

            ROLE_IN_PROJECT role = (ROLE_IN_PROJECT)Session["Role_In_Project"];
            if (role == null)
            {
                return RedirectToAction("ProjectManage", "Users");
            }
            PROJECT project = new UserProjectDAO().FindProjectByID(role.Project_id);
            ViewBag.projectName = project.Project_Name;
            ViewBag.User = Session["user"];


            return View();
        }
        // 7 giai đoạn chỗ này
        public ActionResult Requirement()
        {
            ROLE_IN_PROJECT role = (ROLE_IN_PROJECT)Session["Role_In_Project"];
            if (role == null)
            {
                return RedirectToAction("ProjectManage", "Users");
            }
            else
            {
                if(role.Role_ID != 1)
                {
                    Session.Add("error", "1");

                    if(role.Role_ID == 2)
                    {
                        return RedirectToAction("Development");
                    }
                    else
                    {
                        return RedirectToAction("Tester");
                    }
                }
            }
            return View();
        }
        public ActionResult Analys()
        {
            return View();
        }
        public ActionResult Design()
        {
            return View();
        }
        public ActionResult Development()
        {
            string error = (string)Session["error"];
            if(error != null)
            {
                if (int.Parse(error) == 1)
                {
                    ViewBag.error = 1;
                    Session.Remove("error");
                }
            }
            

            return View();
        }
        public ActionResult Testing()
        {
            string error = (string)Session["error"];
            if (error != null)
            {
                if (int.Parse(error) == 1)
                {
                    ViewBag.error = 1;
                    Session.Remove("error");
                }
            }
            return View();
        }
        public ActionResult Deployment()
        {
            return View();
        }
        public ActionResult Maintenance()
        {
            return View();
        }



        public ActionResult MemberManage()
        {
            if (Session["user"] == null)
            {
                Response.Redirect("https://localhost:44381/Authentication/Login");
            }
            ViewBag.User = Session["user"];

            return View();
        }

        public ActionResult TrackProgress()
        {
            if (Session["user"] == null)
            {
                Response.Redirect("https://localhost:44381/Authentication/Login");
            }
            ViewBag.User = Session["user"];

            return View();
        }

        public ActionResult Reports()
        {
            if (Session["user"] == null)
            {
                Response.Redirect("https://localhost:44381/Authentication/Login");
            }
            ViewBag.User = Session["user"];

            return View();
        }

        public ActionResult ProjectPlan()
        {
            return View();
        }

    }
}