using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMUProektServer.Models
{
    public class ChallengeModel
    {
        public string Challenger { get; set; }
        public string Challenged { get; set; }
        public string Sudoku { get; set; }

        public ChallengeModel()
        {

        }

        public ChallengeModel(string challenger, string challenged, string sudoku)
        {
            this.Challenger = challenger;
            this.Challenged = challenged;
            this.Sudoku = sudoku;
        }

    }
}