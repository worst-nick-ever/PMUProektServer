using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net.Http;
using PMUProektServer.Models;

namespace PMUProektServer.Controllers
{
    public class AccountController : Controller
    {
        KursovProektPMUEntities db = new KursovProektPMUEntities();
        //
        // GET: /Account/Insert
        [ActionName("Insert")]
        public ActionResult Insert()
        {
            return View("InsertAccount");
        }

        [HttpPost]
        [ActionName("InsertAcc")]
        public JsonResult Insert(Account acc)
        {
            db.Account.Add(acc);
            db.SaveChanges();
            return Json(acc, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName("login")]
        public ActionResult Login(Account acc)
        {
            IEnumerable<Account> accs = db.Account.Where(a => a.Name.Equals(acc.Name)).ToList();
            if (accs.Count() > 0)
            {
                if (accs.First().Password.Equals(acc.Password))
                {
                    return View("LoggedIn");
                }
                else
                {
                    return View("InsertAccount");
                }
            }
            else
            {
                return View("InsertAccount");
            }
        }

        public ActionResult AccountWebApiTest()
        {
            return View("AccountWebApiTest");
        }
    }
}
