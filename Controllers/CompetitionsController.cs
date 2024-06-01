using Microsoft.AspNetCore.Mvc;
using OpenMTB.Data;
using OpenMTB.Data.BusinessLogic;
using OpenMTB.Models;

namespace OpenMTB.Controllers;

public class CompetitionsController : Controller
{
    private readonly ILogger<CompetitionsController> _logger;
    private readonly Competitions _competitions;

    public CompetitionsController(ILogger<CompetitionsController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _competitions = new Competitions(context);
    }

    public async Task<IActionResult> List()
    {
        return View(await _competitions.GetCompetitions());
    }
    public async Task<IActionResult> New()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> New(Competition competition)
    {
        await _competitions.CreateCompetition(competition,new List<Series>(),new List<Participant>());
        return RedirectToAction("List");
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _competitions.RemoveCompetition(id);
        return RedirectToAction("List");
    }
}
