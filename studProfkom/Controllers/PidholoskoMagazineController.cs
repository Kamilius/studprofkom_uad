using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using studProfkom.Models;
using System.IO;
using System.Text.RegularExpressions;

namespace studProfkom.Controllers
{
	public class PidholoskoMagazineController : Controller
	{
		//
		// GET: /PidholoskoMagazine/
		private static List<pidholoskoMagazineIssue> _pidholoskoIssueList = new List<pidholoskoMagazineIssue>();

		public ActionResult Archive()
		{
			_pidholoskoIssueList.Clear();
			ScanForIssues();
			return View(_pidholoskoIssueList);
		}
		[HttpGet, Authorize]
		public ActionResult AddIssue()
		{
			return View();
		}
		[HttpPost, Authorize]
		public ActionResult AddIssue(HttpPostedFileBase issueFile, HttpPostedFileBase issueCover)
		{
			if (issueFile != null && issueCover != null)
			{
				if (Path.GetFileNameWithoutExtension(issueFile.FileName) == Path.GetFileNameWithoutExtension(issueCover.FileName))
				{
					if (!System.IO.File.Exists(Path.Combine(Server.MapPath("~/Content/Magazine"), issueFile.FileName)) &&
						!System.IO.File.Exists(Path.Combine(Server.MapPath("~/Content/Magazine"), issueCover.FileName)))
					{
						if (Path.GetExtension(issueFile.FileName) == ".pdf")
						{
							if (issueFile.ContentLength > 0)
							{
								var fileName = issueFile.FileName;
								var path = Path.Combine(Server.MapPath("~/Content/Magazine"), fileName);
								issueFile.SaveAs(path);
							}

						}
						else
						{
							ModelState.AddModelError("Помилка", "Файл журналу має бути у форматі - *.pdf.");
							return View();
						}
						if (Path.GetExtension(issueCover.FileName) == ".jpg" || Path.GetExtension(issueCover.FileName) == ".png")
						{
							if (issueCover.ContentLength > 0)
							{
								var fileName = issueCover.FileName;
								var path = Path.Combine(Server.MapPath("~/Content/Magazine"), fileName);
								issueCover.SaveAs(path);
							}
						}
						else
						{
							ModelState.AddModelError("Помилка", "Файл обкладинки має бути у форматі - *.jpg або *.png.");
							return View();
						}
						return RedirectToAction("Archive", "pidholoskoMagazine");
					}

					ModelState.AddModelError("Помилка", "Один або кілька файлів вже присутні у базі");
					return View();
				}

				ModelState.AddModelError("Помилка", "Файли мають різні імена");
				return View();
			}
			ModelState.AddModelError("Помилка", "Один або кілька файлів - не вибрано");
			return View();
		}

		public void ScanForIssues()
		{
			if (_pidholoskoIssueList.Count <= 0)
			{
				try
				{
					DirectoryInfo dI = new DirectoryInfo(Server.MapPath("/Content/Magazine"));
					FileInfo[] filesList = dI.GetFiles("*.pdf");

					string currentIssueNumberPattern = @"^\d+";
					string generalIssueNumberPattern = @"\(\d+\)";
					string issuePublicationMonthPattern = @"-[01]?[0-9]";
					string issuePublicationYearPattern = @".[0-9]{4}";

					foreach (FileInfo f in filesList)
					{
						Regex issueFileNameParse = new Regex(currentIssueNumberPattern);
						Match currentIssueNumber = issueFileNameParse.Match(f.Name);

						issueFileNameParse = new Regex(generalIssueNumberPattern);
						string generalIssueNumber = issueFileNameParse.Match(f.Name).Value;
						generalIssueNumber = generalIssueNumber.Replace("(", "");
						generalIssueNumber = generalIssueNumber.Replace(")", "");

						issueFileNameParse = new Regex(issuePublicationMonthPattern);
						string issuePublicationMonth = issueFileNameParse.Match(f.Name).Value;
						issuePublicationMonth = issuePublicationMonth.Replace("-", "");

						issueFileNameParse = new Regex(issuePublicationYearPattern);
						string issuePublicationYear = issueFileNameParse.Match(f.Name).Value;
						issuePublicationYear = issuePublicationYear.Replace(".", "");

						_pidholoskoIssueList.Add(new pidholoskoMagazineIssue
						{
							numberThisYear = Convert.ToInt16(currentIssueNumber.Value),
							numberGeneral = Convert.ToInt16(generalIssueNumber),
							publicationDate = new DateTime(Convert.ToInt16(issuePublicationYear), Convert.ToInt16(issuePublicationMonth), 1),
							fileUrl = "/Content/Magazine/" + f.Name
						});
					}
				}
				finally
				{
					_pidholoskoIssueList = _pidholoskoIssueList.OrderByDescending(x => x.publicationDate).ToList();
				}
			}
		}
	}
}
