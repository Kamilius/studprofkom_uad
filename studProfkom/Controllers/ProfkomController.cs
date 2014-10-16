using studProfkom.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace studProfkom.Controllers
{
  public class ProfkomController : Controller
  {
    //
    // GET: /Profkom/
    private EFDbContext _repository;

    public ProfkomController()
    {
      _repository = new EFDbContext();
    }

    public ActionResult Guidance()
    {
      return View();
    }
    public ActionResult Profbureau()
    {
      return View();
    }
    public ActionResult About()
    {
      return View();
    }
    public ActionResult Orphans()
    {
      return View();
    }
    public ActionResult Chummeries()
    {
      var list = new List<Faculty>();
      ViewBag.Faculties = new List<Faculty>();
      ViewBag.Faculties.Add(new Faculty{Id = 0, Name = "Виберіть факультет зі списку"});
      ViewBag.Faculties.AddRange(_repository.Faculties.OrderBy(x => x.Name).ToList());

      return View(_repository.Applications.ToList());
    }
    public ActionResult Students()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Application(Application app)
    {
      if (ModelState.IsValid && app.FacultyId != 0)
      {
        _repository.Applications.Add(new Application
        {
          FullName = app.FullName,
          Faculty = _repository.Faculties.FirstOrDefault(x => x.Id == app.FacultyId),
          City = app.City,
          Phone = app.Phone,
          CreateDate = DateTime.Now
        });
        _repository.SaveChanges();

        return Json(new { message = "success", text = "Заявку успішно надіслано." }, JsonRequestBehavior.AllowGet);
      }
      else
      {
        return Json(new { 
          error = "validation error",
          message = "Усі поля є обов'язковими"
        }, JsonRequestBehavior.AllowGet);
      }
    }
    [Authorize]
    public ActionResult StudentsApplications()
    {
      return View(_repository.Applications.OrderByDescending(x => x.CreateDate).ToList());
    }
  }
}
