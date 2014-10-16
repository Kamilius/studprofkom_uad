using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using studProfkom.Models;

namespace studProfkom.Controllers
{
	public class ProjectsController : Controller
	{
		//
		// GET: /Projects/
		private static List<MissUad> _missList = new List<MissUad>();

		public ProjectsController()
		{
			if (_missList.Count == 0)
			{
				_missList.Add(new MissUad { FirstName = "Наталія", LastName = "Ковтун", Faculty = "ФЕОКС", WinningYear = 2001 });
				_missList.Add(new MissUad { FirstName = "Людмила", LastName = "Ясінська", Faculty = "ФВПІТ", WinningYear = 2002 });
				_missList.Add(new MissUad { FirstName = "Катерина", LastName = "Ішутіна", Faculty = "ФЕОКС", WinningYear = 2003 });
				_missList.Add(new MissUad { FirstName = "Євгенія", LastName = "Бондаренко", Faculty = "ФЕОКС", WinningYear = 2004 });
				_missList.Add(new MissUad { FirstName = "Наталія", LastName = "Червінчак", Faculty = "ФЕОКС", WinningYear = 2005 });
				_missList.Add(new MissUad { FirstName = "Тетяна", LastName = "Мусянович", Faculty = "ФЕОКС", WinningYear = 2006 });
				_missList.Add(new MissUad { FirstName = "Віра", LastName = "Дутчак", Faculty = "ФЕОКС", WinningYear = 2007 });
				_missList.Add(new MissUad { FirstName = "Валерія", LastName = "Гольцева", Faculty = "ФВПІТ", WinningYear = 2008 });
				_missList.Add(new MissUad { FirstName = "Ольга", LastName = "Возняк", Faculty = "ФЕОКС", WinningYear = 2009 });
				_missList.Add(new MissUad { FirstName = "Оксана", LastName = "Секрет", Faculty = "ФЕОКС", WinningYear = 2010 });
				_missList.Add(new MissUad { FirstName = "Анастасія", LastName = "Мацех", Faculty = "ФЕОКС", WinningYear = 2011 });
				_missList.Add(new MissUad { FirstName = "Анастасія", LastName = "Дричик", Faculty = "ЛПК УАД", WinningYear = 2012 });
				_missList = _missList.OrderBy(x => x.WinningYear).ToList();
			}
		}

		public ActionResult MissUad()
		{
			return View(_missList);
		}
		public ActionResult Parties()
		{
			return View();
		}
		public ActionResult SportEvents()
		{
			return View();
		}
		public ActionResult TravelWithUs()
		{
			return View();
		}
		public ActionResult SummerRecovery()
		{
			return View();
		}
		public ActionResult StudentTheater()
		{
			return View();
		}
		public ActionResult StudentArt()
		{
			return View();
		}
		public ActionResult EasterAction()
		{
			return View();
		}
		public ActionResult UkrainianWritingDay()
		{
			return View();
		}
		public ActionResult ScrabbleTourney()
		{
			return View();
		}
		public ActionResult UadTv()
		{
			return View();
		}
		public ActionResult Karaoke()
		{
			return View();
		}
		public ActionResult Charity()
		{
			return View();
		}
	}
}
