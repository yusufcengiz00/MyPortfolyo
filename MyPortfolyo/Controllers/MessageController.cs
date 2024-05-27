using Microsoft.AspNetCore.Mvc;
using MyPortfolyo.DAL.Context;

namespace MyPortfolyo.Controllers
{
	public class MessageController : Controller
	{
		MyPortfolioContext portfolioContext = new MyPortfolioContext();
		public IActionResult InBox()
		{
			var values = portfolioContext.Messages.ToList();
			return View(values);
		}
		public IActionResult ChangeIsReadToTrue(int id)
		{
			var value = portfolioContext.Messages.Find(id);
			value.IsRead = true;
			portfolioContext.SaveChanges();
			return RedirectToAction("InBox");
		}
		public IActionResult ChangeIsReadToFalse(int id)
		{
			var value = portfolioContext.Messages.Find(id);
			value.IsRead = false;
			portfolioContext.SaveChanges();
			return RedirectToAction("InBox");
		}
		public IActionResult DeleteMessage(int id)
		{
			var value = portfolioContext.Messages.Find(id);
			portfolioContext.Messages.Remove(value);
			portfolioContext.SaveChanges();
			return RedirectToAction("InBox");
		}
		public ActionResult MessageDetail(int id) 
		{
			var value = portfolioContext.Messages.Find(id);
			return View(value);
		}
	}
}
