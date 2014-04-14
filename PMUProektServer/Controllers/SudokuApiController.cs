using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PMUProektServer.Models;

namespace PMUProektServer.Controllers
{
    public class SudokuApiController : ApiController
    {
        KursovProektPMUEntities db = new KursovProektPMUEntities();

        // proektpmu.apphb.com/api/SudokuApi/GetSudoku/difficulty
        [HttpGet]
        [ActionName("GetSudoku")]
        public HttpResponseMessage GetSudoku([FromUri]string difficulty)
        {
            var sudokus = db.Sudoku.Where(s => s.Difficulty.Equals(difficulty)).ToList();
            Sudoku result = null;

            while (result == null)
            {
                Random r = new Random();
                result = sudokus.ElementAt(r.Next(0, sudokus.Count() - 1));
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
