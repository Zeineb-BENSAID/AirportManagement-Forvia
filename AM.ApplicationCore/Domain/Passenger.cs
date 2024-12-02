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
    #nullable disable
    [Key]
    [StringLength(7)]
    public string PassportNumber { get; set; }
    [MinLength(3,ErrorMessage ="min lenght is 3 !"),MaxLength(25,ErrorMessage ="max lenght must be 25!")]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TelNumber { get; set; }
    [EmailAddress]
    //[DataType(DataType.EmailAddress)]
    public string EmailAddress { get; set; }

    public virtual ICollection<Flight> Flights{ get; set; }
}
