using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web;
using System.Web.Mvc;

namespace studProfkom.Models
{
    public class NewsArticleViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'Назва' - є обов'язковим"), StringLength(100, ErrorMessage = "Максимальна довжина назви - 100 символів.")]
        public string Title { get; set; }

        public string PublicationDate { get; set; }

        [Required(ErrorMessage = "Поле 'Текст' - не може бути пустим"), AllowHtml]
        public string Text { get; set; }

        public string ImageName { get; set; }

        public bool IsEvent { get; set; }

        public string EventStartDate { get; set; }
        public string EventStartTime { get; set; }

        [StringLength(20, ErrorMessage = "Максимальна довжина опиису події - 20 символів")]
        public string EventShortDescription { get; set; }

        public string GooglePlusUserId { get; set; }

        public string GooglePlusAlbumId { get; set; }

        [StringLength(250, ErrorMessage = "Максимальна довжина опиису новини - 250 символів")]
        public string ArticleShortDescription { get; set; }

        public string FormattedDate(string publicationEvent)
        {
            DateTime pubOrEvent;

            pubOrEvent = publicationEvent == "publication" ? 
                DateTime.ParseExact(PublicationDate, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture) :
				DateTime.ParseExact(EventStartDate, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            var tempDate = pubOrEvent.Day.ToString();

            switch (pubOrEvent.Month)
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
            tempDate += " " + pubOrEvent.Year.ToString();

            return tempDate;
        }

        public DateTime GetDateTime(string publicationEvent)
        {
            if (publicationEvent == "publication")
            {
                return DateTime.ParseExact(PublicationDate, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            }
            else
            {
                return DateTime.ParseExact(EventStartDate, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            }
        }

		public string GetTime(string pubEvent)
		{
			if (pubEvent == "publication")
			{
				return DateTime.ParseExact(PublicationDate, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture).ToString("HH:mm");
			}
			else
			{
				return DateTime.ParseExact(EventStartDate, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture).ToString("HH:mm");
			}
		}
    }
}