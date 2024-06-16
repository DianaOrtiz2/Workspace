using System.Net.Http.Headers;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WAChoferes.Models;
using WAChoferes.Entities;

namespace WAChoferes.Controllers;

public class AutosController : Controller
{
    private readonly ApplicationDbContext _context;
    public AutosController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult AutosList()
    {
      
        List<AutosModel> list = _context.Auto.Select(a => new AutosModel
            {
                Id = a.Id,
                modelo = a.modelo,
                año = a.año,
                placa = a.placa
            }).ToList();

            return View(list);
    }

    public IActionResult AutosAdd()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AutoSave(AutosModel model)
    {
        if(ModelState.IsValid)
        {
            var cars = new Autos();
            cars.Id =  Guid.NewGuid();
            cars.modelo = model.modelo;
            cars.año = model.año;
            cars.placa = model.placa;

            this._context.Auto.Add(cars);
            this._context.SaveChanges();  
            return RedirectToAction("AutosList", "Autos");
        }
        

        return RedirectToAction("AutosAdd", "Autos");
    }

    public IActionResult AutosShowAndEdit(Guid Id)
    {
        Autos? autos = _context.Auto.FirstOrDefault(a => a.Id == Id);
            if (autos == null)
            {
                return RedirectToAction("AutosList", "Autos");
            }
            AutosModel model = new AutosModel
            {
                Id = autos.Id,
                modelo = autos.modelo,
                año = autos.año,
                placa = autos.placa
            };
            return View(model);
    }

    [HttpPost]
    public IActionResult AutosEdit(AutosModel model)
    {
         if (ModelState.IsValid)
    {
        var car = _context.Auto.FirstOrDefault(a => a.Id == model.Id);
        if (car == null)
        {
            return NotFound();
        }

        car.modelo = model.modelo;
        car.año = model.año;
        car.placa = model.placa;

        _context.Auto.Update(car);
        _context.SaveChanges();

        return RedirectToAction("AutosList", "Autos");
    }
        
        return View(model);
        
    }

    public IActionResult AutosShowToDeleted(Guid Id)
    {
        return View();
    }


}
