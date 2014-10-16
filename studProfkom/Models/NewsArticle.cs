using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace studProfkom.Models
{
	public partial class NewsArticle
	{
		public int Id { get; set; }

		public string Title { get; set; }
		public long PublicationDate { get; set; }

		public string Text { get; set; }

		public string ImageName { get; set; }
		public bool IsEvent { get; set; }
		public long? EventStartDate { get; set; }

		public string EventShortDescription { get; set; }

		public string GooglePlusUserId { get; set; }
		public string GooglePlusAlbumId { get; set; }

		public string ArticleShortDescription { get; set; }

		public string FormattedEventDate()
		{
            DateTime eventDate = EventStartDate.HasValue ? new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(EventStartDate.Value) : new DateTime(1970, 1, 1, 0, 0, 0 ,0);

			if (eventDate.Year != 1970)
			{
				var tempDate = eventDate.Day.ToString();

				switch (eventDate.Month)
				{
					case 1:
						tempDate += " січня";
						break;
					case 2:
						tempDate += " лютого";
						break;
					case 3:
						tempDate += " березня";
						break;
					case 4:
						tempDate += " квітня";
						break;
					case 5:
						tempDate += " травня";
						break;
					case 6:
						tempDate += " червня";
						break;
					case 7:
						tempDate += " липня";
						break;
					case 8:
						tempDate += " серпня";
						break;
					case 9:
						tempDate += " вересня";
						break;
					case 10:
						tempDate += " жовтня";
						break;
					case 11:
						tempDate += " листопада";
						break;
					case 12:
						tempDate += " грудня";
						break;
				}
				tempDate += " " + eventDate.Year.ToString();

				return tempDate;
			}
			else
			{
				return "";
			}
		}
	}
}