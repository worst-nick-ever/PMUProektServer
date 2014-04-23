﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PMUProektServer.Models;

namespace PMUProektServer.Controllers
{
    public class ChallengeApiController : ApiController
    {
        KursovProektPMUEntities db = new KursovProektPMUEntities();

        // proektpmu.apphb.com/api/ChallengeApi/InsertChallenge
        [HttpPost]
        [ActionName("InsertChallenge")]
        public HttpResponseMessage InsertChallenge(ChallengeModel challenge)
        {
            if (!db.Account.Any(a => a.Name == challenge.Challenged))
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            var accounts = db.Account.Where(a => a.Name == challenge.Challenger
                || a.Name == challenge.Challenged).ToList();

            if (!challenge.Challenger.Equals(challenge.Challenged))
            {
                if (accounts.Count() != 2)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, -2);
                }
            }

            Sudoku s = new Sudoku();
            s.Difficulty = "chall";
            s.LRU = 0;
            s.Puzzle = challenge.Sudoku;

            int sudokuID = db.Sudoku.Add(s).ID;

            Challenge ch = new Challenge();
            ch.ChallengerID = accounts.Where(a => a.Name == challenge.Challenger).First().ID;
            ch.ChallengedID = accounts.Where(a => a.Name == challenge.Challenged).First().ID;
            ch.SudokuID = sudokuID;
            ch.Accepted = false;
            ch.Completed = false;

            db.Challenge.Add(ch);

            if (db.SaveChanges() > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ch.ID);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, -1);
            }
        }

        // proektpmu.apphb.com/api/ChallengeApi/CompleteChallenge/ID
        [HttpPost]
        [ActionName("CompleteChallenge")]
        public HttpResponseMessage CompleteChallenge([FromUri]int ID)
        {
            Challenge target = null;
            var challenge = db.Challenge.Where(c => c.ID == ID).ToList();
            if (challenge.Count() > 0)
            {
                target = challenge.First();
            }

            target.Completed = true;

            if (db.SaveChanges() > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // proektpmu.apphb.com/api/ChallengeApi/GetChallenges
        [HttpGet]
        [ActionName("GetChallenges")]
        public HttpResponseMessage GetChallenges()
        {
            var challenges = db.CHALLENGES.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, challenges);
        }

        // proektpmu.apphb.com/api/ChallengeApi/GetChallenges/ID
        [HttpGet]
        [ActionName("GetChallenges")]
        public HttpResponseMessage GetChallenges([FromUri]string ID)
        {
            var challenges = db.CHALLENGES.Where(c => c.Challenged.Equals(ID)
                && c.Completed == false).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, challenges);
        }
    }
}
