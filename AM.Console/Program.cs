// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;

Console.WriteLine("Hello, World!");

AMContext AMContext = new AMContext();

IUnitOfWork unitOfWork = new UnitOfWork(AMContext);

IServicePlane servicePlane = new ServicePlane(unitOfWork);

servicePlane.Add(new Plane { Capacity = 400, PlaneType = PlaneType.Boing, ManufactureDate = DateTime.Now });
servicePlane.Commit();  

foreach (var plane in servicePlane.GetAll())
{
    Console.WriteLine(plane.Capacity);
}
