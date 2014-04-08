﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMUProektServer.Models;

namespace PMUProektServer.Controllers
{
    public class HighscoreController : Controller
    {
        KursovProektPMUEntities db = new KursovProektPMUEntities();

        //
        // GET: /Highscore/

        public ActionResult Index()
        {
            IEnumerable<Highscore> highscores = db.Highscore.ToList();
            List<HighscoreModel> model = new List<HighscoreModel>();
            IEnumerable<Account> accounts = db.Account.ToList();

            foreach (var score in highscores)
            {
                HighscoreModel temp = new HighscoreModel();
                temp.Username = accounts.Where(a => a.ID == score.UserID).First().Name;
                temp.Difficulty = score.Difficulty;
                temp.Score = score.Score;
                model.Add(temp);
            }

            return View("HighscoreEditor", model);
        }

    }
}
