using studProfkom.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace studProfkom.Controllers
{
	public class NewsController : Controller
	{
		private EFDbContext _repository;

		public NewsController()
		{
			_repository = new EFDbContext();
		}

		[HttpGet]
		[Authorize]
		public ActionResult EditOrCreateArticle(int id)
		{
			if (id == 0)
			{
				return View(new NewsArticleViewModel());
			}
			else
			{
				var n = _repository.NewsArticles.SingleOrDefault(x => x.Id == id);
				if (n != null)
				{
					return View(new NewsArticleViewModel
					{
						Id = n.Id,
						ArticleShortDescription = n.ArticleShortDescription,
						EventShortDescription = n.EventShortDescription,
						EventStartDate = n.EventStartDate.HasValue ? new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(n.EventStartDate.Value).ToString("dd.MM.yyyy") : "",
						EventStartTime = n.EventStartDate.HasValue ? new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(n.EventStartDate.Value).ToString("HH:mm") : "",
						GooglePlusAlbumId = n.GooglePlusAlbumId,
						GooglePlusUserId = n.GooglePlusUserId,
						ImageName = n.ImageName,
						IsEvent = n.IsEvent,
						PublicationDate = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(n.PublicationDate).ToString("dd.MM.yyyy HH:mm"),
						Text = n.Text,
						Title = n.Title
					});
				}
				else
				{
					return View(new NewsArticleViewModel());
				}
			}
		}

		[HttpPost]
		[Authorize]
		public ActionResult Save(NewsArticleViewModel article,
									   [Required, FileExtensions(ErrorMessage = "Картинка має бути формату: *.jpg або *.png", Extensions = "jpg, png")]
									   HttpPostedFileBase articleImage)
		{
			if (ModelState.IsValid)
			{
				NewsArticle n;

				if (_repository.NewsArticles.Any(x => x.Id == article.Id))
				{
					n = _repository.NewsArticles.Single(x => x.Id == article.Id);
				}
				else
				{
					n = new NewsArticle();
				}

				if (articleImage != null && articleImage.ContentLength > 0)
				{
					if (!System.IO.File.Exists(Server.MapPath(articleImage.FileName)))
					{
						if (n.Id != 0 && !_repository.NewsArticles.Any(x => x.ImageName == n.ImageName && x.Id != n.Id))
						{
							System.IO.File.Delete(Server.MapPath("~/Content/Images/Articles/" + n.ImageName));
						}
						articleImage.SaveAs(Server.MapPath("~/Content/Images/Articles/" + articleImage.FileName));
					}
					else
					{
						if (!_repository.NewsArticles.Any(x => x.ImageName == articleImage.FileName && x.Id != n.Id))
						{
							System.IO.File.Delete(Server.MapPath("~/Content/Images/Articles/" + articleImage.FileName));
						}
					}
					n.ImageName = articleImage.FileName;
				}
				else
				{
					if (String.IsNullOrEmpty(n.ImageName))
					{
						ModelState.AddModelError("", "Зображення не обрано");

						return RedirectToAction("EditOrCreateArticle", article);
					}
				}

				n.ArticleShortDescription = article.ArticleShortDescription;
				n.EventShortDescription = article.EventShortDescription;
				n.EventStartDate = String.IsNullOrEmpty(article.EventStartDate) ? 
					0 : (DateTime.ParseExact(String.Format("{0} {1}", article.EventStartDate, String.IsNullOrEmpty(article.EventStartTime) ? 
					"00:00" : 
					article.EventStartTime), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture).Ticks  - new DateTime(1970, 1, 1, 0, 0, 0, 0).Ticks) / TimeSpan.TicksPerSecond;
				n.PublicationDate = (DateTime.Now.Ticks - new DateTime(1970, 1, 1, 0, 0, 0, 0).Ticks) / TimeSpan.TicksPerSecond;
				n.GooglePlusAlbumId = article.GooglePlusAlbumId;
				n.GooglePlusUserId = article.GooglePlusUserId;
				n.IsEvent = article.IsEvent;
				n.Text = article.Text;
				n.Title = article.Title;

				if (n.Id == 0)
				{
					_repository.NewsArticles.Add(n);
				}

				_repository.SaveChanges();

				return RedirectToAction("Index", "Home");
			}
			else
			{
				return RedirectToAction("EditOrCreateArticle", article);
			}
			return View(article);
		}

		[Authorize]
		public ActionResult Remove(int id)
		{
			string returnUrl = HttpContext.Request.UrlReferrer.ToString();

			var article = _repository.NewsArticles.Single(x => x.Id == id);
			if (article == null)
			{
				return RedirectToAction("Index", "Home");
			}
			_repository.NewsArticles.Remove(article);
			_repository.SaveChanges();

			Uri uri;
			if (!string.IsNullOrEmpty(returnUrl) && Uri.TryCreate(returnUrl, UriKind.RelativeOrAbsolute, out uri))
			{
				return Redirect(returnUrl);
			}
			return RedirectToAction("Index", "Home");
		}

		[Authorize]
		public ActionResult CancelArticle()
		{
			return RedirectToAction("Index", "Home");
		}
	}
}