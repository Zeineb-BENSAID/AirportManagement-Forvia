using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.Web.Controllers;

public class FlightController : Controller
{
    IServiceFlight serviceFlight;
    IServicePlane servicePlane;
    public FlightController(IServiceFlight serviceFlight, IServicePlane servicePlane)
    {
        this.serviceFlight = serviceFlight;
        this.servicePlane = servicePlane;

    }

    // GET: FlightController
    public ActionResult Index(DateTime? dateDepart)
    {
        if(dateDepart==null)
            return View(serviceFlight.GetAll());
        return View(serviceFlight.GetMany(f=>f.FlightDate.Equals(dateDepart)).ToList());
    }
    public ActionResult IndexWithPartialView()
    {
            return View(serviceFlight.GetAll());
    }
    public ActionResult Sort() // appel de service spécifique
    {
        return View("Index", serviceFlight.SortFlights());
    }

    // GET: FlightController/Details/5
    public ActionResult Details(int id)
    {
        return View(serviceFlight.GetById(id));
    }

    // GET: FlightController/Create
    [HttpGet]
    public ActionResult Create()
    {
        ViewBag.Planes = new SelectList(servicePlane.GetAll().ToList(),
                "PlaneId", "Capacity");

        return View();
    }

    // POST: FlightController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Flight flight,IFormFile AirlineLogo)
    {
        try
        {
            if (AirlineLogo != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", AirlineLogo.FileName); //création du chemin
                Stream stream = new FileStream(path, FileMode.Create); AirlineLogo.CopyTo(stream); // ajout dans le dossier
                flight.AirlineLogo = AirlineLogo.FileName;//nom du logo dans la base
            }
            serviceFlight.Add(flight);
            serviceFlight.Commit();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: FlightController/Edit/5
    public ActionResult Edit(int id)
    {
        ViewBag.myplanes =new SelectList(servicePlane.GetAll(), "PlaneId", "Information");
        return View(serviceFlight.GetById(id));
    }

    // POST: FlightController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Flight flight)
    {
        try
        {
            flight.FlightId = id;
            serviceFlight.Update(flight);
            serviceFlight.Commit();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: FlightController/Delete/5
    public ActionResult Delete(int id)
    {
        return View(serviceFlight.GetById(id));
    }

    // POST: FlightController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Flight flight)
    {
        try
        {
            flight.FlightId = id;
            serviceFlight.Delete(flight);
            serviceFlight.Commit();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
