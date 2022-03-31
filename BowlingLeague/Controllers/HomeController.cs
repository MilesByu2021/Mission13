using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BowlingLeague.Models;
using Microsoft.EntityFrameworkCore;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        //private BowlingDbContext _context { get; set; }

        // Setting a repositoey adds a layer between the Dbcontext and Controller,
        // it does the same thing without the repository but you can test dumy codes on the repository
        private IBowlersRepository _repo { get; set; }

        //Constructor
        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(string teamName)
        {
            var blah = _repo.Bowlers
                .Include("Team")
                .Where(b => b.Team.TeamName == teamName || teamName == null)
                .ToList();

            ViewData["TeamName"] = teamName;

            return View(blah);
        }
    }
}


