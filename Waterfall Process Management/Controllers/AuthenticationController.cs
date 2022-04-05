using DatabaseModels.DataAccessObject;
using DatabaseWPMSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Waterfall_Process_Management.Controllers
{
    public class AuthenticationController : Controller
    {
        //check username pass
        [HttpPost]
        public JsonResult CheckLogin(FormCollection data)
        {
            string username = data["username"];
            string password = data["password"];

            JsonResult jr = new JsonResult();
            AccountDAO db = new AccountDAO();
            ACCOUNT u = db.GetObjectUserByUserName(username);
            // kiểm tra username
            // nếu rỗng
            if (u == null)
            {
                jr.Data = new
                {
                    status = "ERROR"
                };
            }
            else
            {
                // nếu có username thì ktra password
                if (u.Passwords == password)
                {
                    Session["user"] = u;
                    Session.Timeout = 20; // 20 phút
                    //xét Role để phân quyền, chuyển trang
                    if (u.iAdmin.ToString() == "True")
                    {
                        jr.Data = new
                        {
                            status = "OK1"
                        };
                    }
                    else
                    {
                        jr.Data = new
                        {
                            status = "OK2"
                        };
                    }

                }
                else
                {
                    jr.Data = new
                    {
                        status = "ERROR"
                    };
                }
            }
            return Json(jr, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login()
        {
            if (Session["user"] != null)
            {
                ACCOUNT user = (ACCOUNT)Session["user"];
                string iadmin = user.iAdmin.ToString();

                if (iadmin == "True")
                {
                    Response.Redirect("https://localhost:44381/Admin/AccountManage");
                }
                else
                {
                    Response.Redirect("https://localhost:44381/Users/CreateProject");
                }
            }
            return View();
        }

        //logout
        //xử lý logout
        [HttpPost]
        public JsonResult Logout()
        {
            JsonResult jr = new JsonResult();
            if (Session["user"] != null)
            {
                Session["user"] = null;
                jr.Data = new
                {
                    status = "OK"
                };
            }
            return Json(jr, JsonRequestBehavior.AllowGet);
        }
    }
}