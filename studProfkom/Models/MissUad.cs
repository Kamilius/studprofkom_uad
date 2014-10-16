namespace studProfkom.Models
{
    public class MissUad
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int WinningYear { get; set; }
        public string Faculty { get; set; }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
        public string MissListItem()
        {
            return WinningYear.ToString() + " " + "рік - " + FullName() + ", " + Faculty;
        }
    }
}