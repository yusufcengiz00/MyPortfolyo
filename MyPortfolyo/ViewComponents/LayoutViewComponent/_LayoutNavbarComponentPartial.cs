using Microsoft.AspNetCore.Mvc;
using MyPortfolyo.DAL.Context;

namespace MyPortfolyo.ViewComponents.LayoutViewComponent
{
	public class _LayoutNavbarComponentPartial : ViewComponent
	{
		MyPortfolioContext portfolioContext = new MyPortfolioContext();
		public IViewComponentResult Invoke()
		{
			ViewBag.toDoListCount = portfolioContext.ToDoLists.Where(x=>x.Status==false).Count();
			var values = portfolioContext.ToDoLists.Where(x=>x.Status==false).ToList();
			return View(values);
		}
	}
}
