using StackExchange.Profiling;
using studProfkom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace studProfkom.Controllers
{
	public class HomeController : Controller
	{
		//
		// GET: /Home/
		private EFDbContext _repository;

		public HomeController()
		{
			_repository = new EFDbContext();
		}

		public ActionResult Index()
		{
			var profiler = MiniProfiler.Current; // it's ok if this is null

			List<NewsArticleViewModel> articleList;

			using (profiler.Step("Getting articles for index page"))
			{
				articleList = _repository.NewsArticles.OrderByDescending(x => x.Id).Take(8).ToList().Select(n => new NewsArticleViewModel
				{
					Id = n.Id,
					ArticleShortDescription = n.ArticleShortDescription,
					EventShortDescription = n.EventShortDescription,
					EventStartDate = n.EventStartDate.HasValue && n.EventStartDate.Value > 0 ? new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(n.EventStartDate.Value).ToString("dd.MM.yyyy HH:mm") : "",
					GooglePlusAlbumId = n.GooglePlusAlbumId,
					GooglePlusUserId = n.GooglePlusUserId,
					ImageName = n.ImageName,
					IsEvent = n.IsEvent,
					PublicationDate = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(n.PublicationDate).ToString("dd.MM.yyyy HH:mm"),
					Text = n.Text,
					Title = n.Title
				}).ToList();
			}
			
			return View(articleList);
		}

		public ActionResult Contacts()
		{
			return View();
		}

		public ActionResult News()
		{
			var articleList = _repository.NewsArticles.OrderByDescending(x => x.Id).ToList().Select(x => new NewsArticleViewModel
			{
				Id = x.Id,
				ArticleShortDescription = x.ArticleShortDescription,
				EventShortDescription = x.EventShortDescription,
				EventStartDate = x.EventStartDate.HasValue && x.EventStartDate.Value > 0 ? new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(x.EventStartDate.Value).ToString("dd.MM.yyyy HH:mm") : "",
				GooglePlusAlbumId = x.GooglePlusAlbumId,
				GooglePlusUserId = x.GooglePlusUserId,
				ImageName = x.ImageName,
				IsEvent = x.IsEvent,
				PublicationDate = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(x.PublicationDate).ToString("dd.MM.yyyy HH:mm"),
				Text = x.Text,
				Title = x.Title
			}).ToList();
			return View(articleList);
		}

		public ActionResult ArticleDetails(int id)
		{
			var article = _repository.NewsArticles.FirstOrDefault(x => x.Id == id);

			if (article == null)
			{
				return RedirectToAction("Index");
			}
			return View(new NewsArticleViewModel
			{
				Id = article.Id,
				ArticleShortDescription = article.ArticleShortDescription,
				EventShortDescription = article.EventShortDescription,
				EventStartDate = article.EventStartDate.HasValue && article.EventStartDate.Value > 0 ? new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(article.EventStartDate.Value).ToString("dd.MM.yyyy HH:mm") : "",
				GooglePlusAlbumId = article.GooglePlusAlbumId,
				GooglePlusUserId = article.GooglePlusUserId,
				ImageName = article.ImageName,
				IsEvent = article.IsEvent,
				PublicationDate = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(article.PublicationDate).ToString("dd.MM.yyyy HH:mm"),
				Text = article.Text,
				Title = article.Title
			});
		}

		public static double ConvertToUnixTimestamp(DateTime date)
		{
			DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			TimeSpan diff = date.ToUniversalTime() - origin;
			return Math.Floor(diff.TotalSeconds);
		}

		public ActionResult EventsWidget()
		{
			var today = ConvertToUnixTimestamp(DateTime.Today);
			var eventWidget = _repository.NewsArticles.Where(x => x.IsEvent == true && x.EventStartDate >= today).OrderBy(x => x.EventStartDate.Value).Take(3).ToList().Select(y => new EventWidgetViewModel
			{
				Id = y.Id,
				Title = y.Title,
				Date = y.FormattedEventDate(),
				Description = y.EventShortDescription,
				ImageName = y.ImageName
			});
			return View(eventWidget.ToList());
		}

		public ActionResult Events()
		{
			var articleList = _repository.NewsArticles.Where(x => x.IsEvent == true).OrderByDescending(x => x.Id).ToList().Select(x => new NewsArticleViewModel
			{
				Id = x.Id,
				ArticleShortDescription = x.ArticleShortDescription,
				EventShortDescription = x.EventShortDescription,
				EventStartDate = x.EventStartDate.HasValue && x.EventStartDate.Value > 0 ? new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(x.EventStartDate.Value).ToString("dd.MM.yyyy HH:mm") : "",
				GooglePlusAlbumId = x.GooglePlusAlbumId,
				GooglePlusUserId = x.GooglePlusUserId,
				ImageName = x.ImageName,
				IsEvent = x.IsEvent,
				PublicationDate = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(x.PublicationDate).ToString("dd.MM.yyyy HH:mm"),
				Text = x.Text,
				Title = x.Title
			}).ToList();
			return View(articleList);
		}

		public ActionResult Gallery()
		{
			return View();
		}
	}
}