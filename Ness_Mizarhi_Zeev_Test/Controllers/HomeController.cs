using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ness_Mizarhi_Zeev_Test.Core.Data;
using Ness_Mizarhi_Zeev_Test.Core.Models;

namespace Ness_Mizarhi_Zeev_Test.Controllers;

public class HomeController : Controller
{
    private readonly MathOperationsDbContext _db;

    public HomeController(MathOperationsDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        Operation? op = await _db.Operations.FirstOrDefaultAsync();
        return View(op);
    }
}
