using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain;

public  class Flight
{
    public int FlightId { get; set; }
    #nullable disable
    public string Departure { get; set; }
    public string Destination { get; set; }
    public DateTime FlightDate { get; set; }
    public DateTime EffectiveArrival { get; set; }
    public int EstimatedDuration { get; set; }
    public string AirlineLogo { get; set; }
    public int? PlaneFK { get; set; }
    //prop de navigation
    [ForeignKey("PlaneFK")]
    public virtual Plane Plane{ get; set; }
    public virtual ICollection<Passenger> Passengers { get; set; }

}
