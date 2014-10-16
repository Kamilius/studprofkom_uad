using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace studProfkom.Models
{
    public class pidholoskoMagazineIssue
    {
        public int numberGeneral { get; set; }
        public int numberThisYear { get; set; }
        public DateTime publicationDate { get; set; }
        public string fileUrl { get; set; }

        public string formattedDate()
        {
            string tempDate = String.Empty;

            switch (publicationDate.Month)
            {
                case 1:
                    tempDate += "Січень";
                    break;
                case 2:
                    tempDate += "Лютий";
                    break;
                case 3:
                    tempDate += "Березень";
                    break;
                case 4:
                    tempDate += "Квітень";
                    break;
                case 5:
                    tempDate += "Травень";
                    break;
                case 6:
                    tempDate += "Червень";
                    break;
                case 7:
                    tempDate += "Липень";
                    break;
                case 8:
                    tempDate += "Серпень";
                    break;
                case 9:
                    tempDate += "Вересень";
                    break;
                case 10:
                    tempDate += "Жовтень";
                    break;
                case 11:
                    tempDate += "Листопад";
                    break;
                case 12:
                    tempDate += "Грудень";
                    break;
            }
            tempDate += " " + publicationDate.Year.ToString();

            return tempDate;
        }
        public string formattedNumber()
        {
            return numberThisYear.ToString() + " (" + numberGeneral.ToString() + ")";
        }
    }
}