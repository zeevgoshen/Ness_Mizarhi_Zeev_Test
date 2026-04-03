using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ness_Mizarhi_Zeev_Test.Core.Data;

namespace Ness_Mizarhi_Zeev_Test.Controllers;

public class HomeController : Controller
{
    private readonly IReadDbContext _db;

    public HomeController(IReadDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        var op = await _db.Operations.ToListAsync();
        return View(op);
    }
}
