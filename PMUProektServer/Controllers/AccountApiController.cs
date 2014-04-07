using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using PMUProektServer.Models;

namespace PMUProektServer.Controllers
{
    public class AccountApiController : ApiController
    {
        KursovProektPMUEntities db = new KursovProektPMUEntities();

        //  api/account/login
        [HttpPost]
        [ActionName("Login")]
        public HttpResponseMessage Login(Account acc)
        {
            IEnumerable<Account> accs = db.Account.Where(a => a.Name.Equals(acc.Name)).ToList();
            if (accs.Count() > 0)
            {
                if (accs.First().Password.Equals(acc.Password))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // api/account/register
        [HttpPost]
        [ActionName("Register")]
        public HttpResponseMessage Register(Account acc)
        {
            db.Account.Add(acc);
            int savedToDb = db.SaveChanges();
            if (savedToDb > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
