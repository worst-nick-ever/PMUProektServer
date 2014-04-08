using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMUProektServer.Models
{
    public class HighscoreModel
    {
        public string Username { get; set; }
        public string Difficulty { get; set; }
        public long Score { get; set; }

        public HighscoreModel()
        {

        }

        public HighscoreModel(string username, string difficulty, long score)
        {
            this.Username = username;
            this.Difficulty = difficulty;
            this.Score = score;
        }
    }
}