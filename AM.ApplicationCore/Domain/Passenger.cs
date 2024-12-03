using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain;

public class Passenger
{
    [Display(Name ="Date of birth")]
    [DataType(DataType.Date)] // calender
    public DateTime BirthDate{ get; set; }
  
    [Key]
    [StringLength(7)]
    public string PassportNumber { get; set; }
    public FullName FullName { get; set; } // type complexe
    public string TelNumber { get; set; }
    [EmailAddress]
    //[DataType(DataType.EmailAddress)]
    public string EmailAddress { get; set; }

    public virtual ICollection<Flight> Flights{ get; set; }
}
