using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PMUProektServer.Models;

namespace PMUProektServer.Controllers
{
    public class HighscoreApiController : ApiController
    {
        KursovProektPMUEntities db = new KursovProektPMUEntities();

        [HttpPost]
        [ActionName("Insert")]
        public HttpResponseMessage Insert(HighscoreModel score)
        {
            var account = db.Account.Where(a => a.Name.Equals(score.Username)).ToList();
            if (account.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Highscore temp = new Highscore();
            temp.UserID = account.First().ID;
            temp.Difficulty = score.Difficulty;
            temp.Score = score.Score;

            db.Highscore.Add(temp);
            int saved = db.SaveChanges();

            if (saved > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [ActionName("GetHighscores")]
        public HttpResponseMessage GetHighscores()
        {

            var highscores = db.Highscore.Join(db.Account,
                h => h.UserID, a => a.ID,
                (h, a) => new
            {
                Username = a.Name,
                Difficulty = h.Difficulty,
                Score = h.Score
            }).OrderBy(h => h.Score).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, highscores);
        }

        [HttpGet]
        [ActionName("GetHighscores")]
        public HttpResponseMessage GetHighscores([FromUri]string id)
        {

            var highscores = db.Highscore.Join(db.Account,
                h => h.UserID, a => a.ID,
                (h, a) => new
                {
                    Username = a.Name,
                    Difficulty = h.Difficulty,
                    Score = h.Score
                }).OrderBy(h => h.Score).ToList();

            if (id != null)
            {
                highscores = highscores.Where(a => a.Difficulty.Equals(id)).ToList();
            }

            return Request.CreateResponse(HttpStatusCode.OK, highscores);
        }
    }
}
