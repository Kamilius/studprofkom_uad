using System;
using System.Collections.Generic;

namespace studProfkom.Models
{
    public partial class Application
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public DateTime CreateDate { get; set; }
        public int FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}
