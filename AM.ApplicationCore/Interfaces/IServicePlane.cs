using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces;

public interface IServicePlane:IService<Plane>
{
    // signatures des méthodes avancées (sauf CRUD)
    public IEnumerable<Passenger> GetPassengers(Plane p);
    public IEnumerable<Flight> GetFlights(int n);
    public void DeleteOldPlanes();
}
