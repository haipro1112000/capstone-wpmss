using DatabaseModels.DataAccessObject;
using DatabaseModels.ModelView;
using DatabaseWPMSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Waterfall_Process_Management.Controllers
{
    public class UsersController : Controller
    {
        //Post Create Project
        public ActionResult CreateProject()
        {
            if (Session["user"] == null)
            {
                Response.Redirect("https://localhost:44381/Authentication/Login");
            }

            // lấy tên username điền vào combobox
            AccountDAO acc = new AccountDAO();
            ViewBag.username = acc.getAcc();

            return View();
        }

        //add job
        [HttpPost]
        public JsonResult AddProject(FormCollection data)
        {
            // nhan may cai do tu form data gui ve
            string projectName = data["projectName"];
            string projectType = data["projectType"];
            string projectManager = data["projectManager"];
            string startDate = data["startDate"];
            string endDate = data["endDate"];
            string projectDescription = data["projectDescription"];
            //string accid = data["accid"];
            string roleDefaultCreatePrject = data["roleDefaultCreatePrject"];

            // đặt một biến Json 
            JsonResult jr = new JsonResult();
            // kết quả trả về sẽ là một Json
            if (String.IsNullOrEmpty(projectName) || String.IsNullOrEmpty(projectType) || String.IsNullOrEmpty(projectManager) || String.IsNullOrEmpty(startDate)
                || String.IsNullOrEmpty(endDate) || String.IsNullOrEmpty(projectDescription) || String.IsNullOrEmpty(roleDefaultCreatePrject))
            {
                jr.Data = new
                {
                    status = "ERROR",
                    message = "You must fill enough info!!"

                };
            }
            else
            {
                // khai báo CreateProjectDAO để lấy các hàm đã viết
                CreateProjectDAO db = new CreateProjectDAO();
                // Gọi database muốn add 
                PROJECT project = new PROJECT();
                project.Project_Name = projectName;
                project.Project_Type = projectType;
                project.Project_Manager = projectManager;
                DateTime a = DateTime.Parse(startDate);
                DateTime b = DateTime.Parse(endDate);
                project.Estimated_Start = a ;
                project.Estimated_End = b;
                project.Project_Des = projectDescription;

                ACCOUNT acc = (ACCOUNT)Session["user"];
                int accid = acc.Acc_ID;

                project.Acc_ID = accid;
                project.Role_ID = Int32.Parse(roleDefaultCreatePrject);


                // gọi hàm AddObject 
                db.AddObject(project);
                db.Save();
                jr.Data = new
                {
                    status = "OK"
                };
            }
            return Json(jr, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProjectManage()
        {
            if (Session["user"] == null)
            {
                Response.Redirect("https://localhost:44381/Authentication/Login");
            }
            if (Session["error"] != null)
            {
                ViewBag.result = Session["error"];
                Session.Remove("error");
            }

            List<PROJECT> projects = new CreateProjectDAO().FindAll();

            

            return View(projects);
        }
        public ActionResult ProjectCompleted()
        {
            if (Session["user"] == null)
            {
                Response.Redirect("https://localhost:44381/Authentication/Login");
            }
            return View();
        }
    }
}