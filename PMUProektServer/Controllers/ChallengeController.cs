using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMUProektServer.Controllers
{
    public class ChallengeController : Controller
    {
        //
        // GET: /Challenge/

        [ActionName("ChallengeEditor")]
        public ActionResult ChallengeEditor()
        {
            return View("ChallengeEditor");
        }

    }
}
