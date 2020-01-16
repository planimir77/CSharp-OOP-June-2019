using CompetitorEntries.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CompetitorEntries.Controllers
{
    public class CompetitorController : Controller
    {
        private readonly CompetitorEntriesDbContext context;

        public CompetitorController(CompetitorEntriesDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            using (var db = new CompetitorEntriesDbContext())
            {
                var competitors = db.Competitors.ToList();
                return View(competitors);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Competitor competitor)
        {
            if (ModelState.IsValid)
            {
                using (var db = new CompetitorEntriesDbContext())
                {
                    var tempCompetitor = new Competitor
                    {
                        Name = competitor.Name,
                        Age = competitor.Age,
                        Team = competitor.Team,
                        Category = competitor.Category
                    };
                    db.Competitors.Add(tempCompetitor);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                using (var db = new CompetitorEntriesDbContext())
                {
                    var competitorsToEdit = db.Competitors.FirstOrDefault(x => x.Id == id);
                    return View(competitorsToEdit);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Competitor competitor)
        {
            if (ModelState.IsValid)
            {
                using (var db = new CompetitorEntriesDbContext())
                {
                    var competitorToEdit = db.Competitors.FirstOrDefault(x => x.Id == competitor.Id);
                    competitorToEdit.Name = competitor.Name;
                    competitorToEdit.Age = competitor.Age;
                    competitorToEdit.Team = competitor.Team;
                    competitorToEdit.Category = competitor.Category;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                using (var db = new CompetitorEntriesDbContext())
                {
                    var competitorToDelete = db.Competitors.FirstOrDefault(x => x.Id == id);
                    return this.View(competitorToDelete);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Competitor competitor)
        {
            using (var db = new CompetitorEntriesDbContext())
            {
                db.Competitors.Remove(competitor);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}