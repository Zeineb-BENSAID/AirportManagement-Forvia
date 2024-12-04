using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.Web.Controllers;

public class FlightController : Controller
{
    IServiceFlight serviceFlight;
    public FlightController(IServiceFlight serviceFlight)
    {
        this.serviceFlight=serviceFlight;
    }

    // GET: FlightController
    public ActionResult Index(DateTime? dateDepart)
    {
        if(dateDepart==null)
            return View(serviceFlight.GetAll());
        return View(serviceFlight.GetMany(f=>f.FlightDate.Equals(dateDepart)).ToList());
    }
    public ActionResult Sort() // appel de service spécifique
    {
        return View("Index", serviceFlight.SortFlights());
    }

    // GET: FlightController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: FlightController/Create
    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    // POST: FlightController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Flight flight)
    {
        try
        {
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
        return View();
    }

    // POST: FlightController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
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
        return View();
    }

    // POST: FlightController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
