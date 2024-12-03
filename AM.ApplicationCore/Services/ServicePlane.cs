using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services;

public class ServicePlane : Service<Plane>, IServicePlane
{
    // implémentations des méthodes spécifiques
    public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public void DeleteOldPlanes()
    {
        Delete(p => p.ManufactureDate.Year < DateTime.Now.Year - 10);
    }

    public IEnumerable<Flight> GetFlights(int n)
    {
        return GetAll().TakeLast(n).SelectMany(p=>p.Flights)
            .OrderByDescending(f=>f.FlightDate).AsEnumerable();
    }

    public IEnumerable<Passenger> GetPassengers(Plane p)
    {
        return p.Flights.SelectMany(f=>f.Passengers).AsEnumerable();
    }
    public IList<Passenger> GetPassengers2(int idp)
    {
        return GetById(idp).Flights.SelectMany(f => f.Passengers).ToList();
    }
}
