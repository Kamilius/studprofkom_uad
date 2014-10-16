using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace studProfkom.Models
{
  public partial class Faculty
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual List<Application> Applications { get; set; }
  }
}
