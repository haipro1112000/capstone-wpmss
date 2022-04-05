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
    public class AdminController : Controller
    {
        public ActionResult AccountManage()
        {
            if (Session["user"] == null)
            {
                Response.Redirect("https://localhost:44381/Authentication/Login");
            }

            AccountDAO ac = new AccountDAO();
            ViewBag.Username = ac.GetUsername();

            // để lấy tên theo session user hiện tại.
            ViewBag.User = Session["user"];

            //load du lieu len bang
            AccountDAO db = new AccountDAO();
            List<ACCOUNT> acc = db.getAcc();

            return View(acc);
        }

        // ADD 1 ACCOUNT
        [HttpPost]
        public JsonResult AddAccount(FormCollection data)
        {
            // nhận các dữ liệu từ form data
            string fullname = data["fullname"];
            string username = data["username"];
            string password = data["password"];

            // đặt một biến Json 
            JsonResult jr = new JsonResult();
            // kết quả trả về sẽ là một Json
            if (String.IsNullOrEmpty(fullname) || String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                jr.Data = new
                {
                    status = "ERROR",
                    message = "You must fill enough !!"
                };
            }
            else
            {
                // khai báo AccountDAO để lấy các hàm đã viết
                AccountDAO db = new AccountDAO();
                // Gọi database muốn add 
                ACCOUNT acc = new ACCOUNT();
                acc.MemberName = fullname;
                acc.Username = username;
                acc.Passwords = password;

                // gọi hàm AddObject để thêm ACCOUNT
                db.AddObject(acc);
                // Gọi hàm Save() để lưu mọi thay đổi
                db.Save();

                jr.Data = new
                {
                    status = "OK"
                };
            }
            return Json(jr, JsonRequestBehavior.AllowGet);
        }
        // end Add ACCOUNT

        // UPDATE 1 ACCOUNT
        [HttpPost]
        public JsonResult UpdateAccount(FormCollection data)
        {
            string id = data["accid"];
            int idAcc = int.Parse(id);

            string fullname = data["fullname"];
            string username = data["username"];
            string password = data["password"];

            JsonResult jr = new JsonResult();
            if ( String.IsNullOrEmpty(fullname) || String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                jr.Data = new
                {
                    status = "ERROR",
                    message = "You must fill enough!!"
                };
            }
            else
            {
                // khai báo ManageRecruiterDAO để lấy các hàm đã viết
                AccountDAO db = new AccountDAO();
                ACCOUNT acc = db.GetAccByAccID(idAcc);
                acc.MemberName = fullname;
                acc.Username = username;
                acc.Passwords = password;

                // Gọi hàm Save() để lưu mọi thay đổi
                db.Save();

                jr.Data = new
                {
                    status = "OK"
                };
            }
            return Json(jr, JsonRequestBehavior.AllowGet);
        }
        // end update account

        // ham xu ly delete Candidate
        [HttpPost]
        public JsonResult DeleteAccount(FormCollection data)
        {
            string id = data["idAcc"];
            int idAcc = int.Parse(id);

            JsonResult jr = new JsonResult();
            if (String.IsNullOrEmpty(id))
            {
                jr.Data = new
                {
                    status = "NOT FOUND",
                    message = "Note found"
                };
            }
            else
            {
                AccountDAO db = new AccountDAO();
                ACCOUNT acc = db.GetAccByAccID(idAcc);
                if (acc == null)
                {
                    jr.Data = new
                    {
                        status = "ERROR",
                        message = "ACCOUNT note exist"
                    };
                }
                else
                {
                    db.DeleteObject(acc);
                    db.Save();
                    jr.Data = new
                    {
                        status = "OK"
                    };
                }
            }
            return Json(jr, JsonRequestBehavior.AllowGet);
        }
    
        public JsonResult GetName()
        {

            return ViewBag;
        }

    }
}