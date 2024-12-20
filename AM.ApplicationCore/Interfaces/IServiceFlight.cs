﻿using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces;
public interface IServiceFlight:IService<Flight>
{
    //signatures des méthodes avancées
    public IEnumerable<Flight> SortFlights();
}
