using System;
using System.Linq;
using System.Threading.Tasks;
using BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;

namespace BowlingLeague.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private ITeamsRepository repo { get; set; }

        public NavigationMenuViewComponent (ITeamsRepository temp)
        {
            repo = temp;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.SelectedType = RouteData?.Values["teamName"];

            var types = repo.Teams
                .Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x);

            return View(types);

        }
    }
}
