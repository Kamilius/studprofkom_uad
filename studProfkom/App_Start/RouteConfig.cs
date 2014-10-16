using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace studProfkom
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
        name: "post_details",
        url: "article/{id}",
        defaults: new { controller = "Home", action = "ArticleDetails" }
      );
      routes.MapRoute(
        name: "articles",
        url: "articles",
        defaults: new { controller = "Home", action = "News" }
      );
      routes.MapRoute(
        name: "events",
        url: "events",
        defaults: new { controller = "Home", action = "Events" }
      );

      //Розділ "Профком"
      routes.MapRoute(
        name: "profkom/for-students",
        url: "profkom/for-students",
        defaults: new { controller = "Profkom", action = "Students" }
      );
      routes.MapRoute(
        name: "profkom/for-orphans",
        url: "profkom/for-orphans",
        defaults: new { controller = "Profkom", action = "Orphans" }
      );
      routes.MapRoute(
        name: "profkom/chummeries",
        url: "profkom/chummeries",
        defaults: new { controller = "Profkom", action = "Chummeries" }
      );
      routes.MapRoute(
        name: "profkom/guidance",
        url: "profkom/guidance",
        defaults: new { controller = "Profkom", action = "Guidance" }
      );
      routes.MapRoute(
        name: "profkom/profbureau",
        url: "profkom/profbureau",
        defaults: new { controller = "Profkom", action = "Profbureau" }
      );
      routes.MapRoute(
        name: "profkom/about",
        url: "profkom/about",
        defaults: new { controller = "Profkom", action = "About" }
      );
      routes.MapRoute(
        name: "profkom",
        url: "profkom",
        defaults: new { controller = "Profkom", action = "Guidance" }
      );
      //розділ "Проекти"
      routes.MapRoute(
        name: "missUAD",
        url: "projects/miss-uad",
        defaults: new { controller = "Projects", action = "MissUad" }
      );
      routes.MapRoute(
        name: "Parties",
        url: "projects/parties",
        defaults: new { controller = "Projects", action = "Parties" }
      );
      routes.MapRoute(
        name: "SportEvents",
        url: "projects/sport-events",
        defaults: new { controller = "Projects", action = "SportEvents" }
      );
      routes.MapRoute(
        name: "TravelWithUs",
        url: "projects/travel-with-us",
        defaults: new { controller = "Projects", action = "TravelWithUs" }
      );
      routes.MapRoute(
        name: "SummerRecovery",
        url: "projects/summer-recovery",
        defaults: new { controller = "Projects", action = "SummerRecovery" }
      );
      routes.MapRoute(
        name: "StudentTheater",
        url: "projects/student-theater",
        defaults: new { controller = "Projects", action = "StudentTheater" }
      );
      routes.MapRoute(
        name: "StudentArtFestivals",
        url: "projects/student-art-festivals",
        defaults: new { controller = "Projects", action = "StudentArt" }
      );
      routes.MapRoute(
        name: "EasterAction",
        url: "projects/easter-actions",
        defaults: new { controller = "Projects", action = "EasterAction" }
      );
      routes.MapRoute(
        name: "UkrainianWritingDay",
        url: "projects/ukrainian-writing-day",
        defaults: new { controller = "Projects", action = "UkrainianWritingDay" }
      );
      routes.MapRoute(
        name: "ScrabbleTourney",
        url: "projects/scrabble-tourney",
        defaults: new { controller = "Projects", action = "ScrabbleTourney" }
      );
      routes.MapRoute(
        name: "UadTv",
        url: "projects/uad-tv",
        defaults: new { controller = "Projects", action = "UadTv" }
      );
      routes.MapRoute(
        name: "Karaoke",
        url: "projects/karaoke",
        defaults: new { controller = "Projects", action = "Karaoke" }
      );
      routes.MapRoute(
        name: "Charity",
        url: "projects/charity",
        defaults: new { controller = "Projects", action = "Charity" }
      );

      routes.MapRoute(
        name: "gallery",
        url: "gallery",
        defaults: new { controller = "Home", action = "Gallery" }
      );

      routes.MapRoute(
        name: "pidholosko-magazine",
        url: "pidholosko-76",
        defaults: new { controller = "PidholoskoMagazine", action = "Archive" }
      );

      routes.MapRoute(
        name: "contacts",
        url: "contacts",
        defaults: new { controller = "Home", action = "Contacts" }
      );

      routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
      );
    }
  }
}