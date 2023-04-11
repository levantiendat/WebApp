using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp1.Models;
using WebApp1.Models.Entities;

namespace WebApp1.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
		
		public IActionResult CheckingAccount(string MSSV,string Password)
		{
			
            DbhocphanContext db=new DbhocphanContext();
			var s = db.Logins.Where(p => p.Mssv == MSSV && p.Password == Password).Select(p=>p).FirstOrDefault();
			if(s!=null)
			{
				return RedirectToAction("Login", "Detail", new {mssv=MSSV});
			}
			return RedirectToAction("LoginFail", "Detail");
		}
		
		
	}
}