using System.Reflection;
using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;
using System.Globalization;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WAChoferes.Models;
using WAChoferes.Entities;



namespace WAChoferes.Controllers;

public class DriversController : Controller
{

    private readonly ApplicationDbContext _context;
    public DriversController(ApplicationDbContext context)
    {
        _context = context;
    }
     
    public IActionResult DriversList()
    {
      
         /*Actualizar*/
      /*   Drivers ChoferActualiza = this._context.Driver.Where(c => c.Id == drivers.Id;).First();

        this._context.Driver.Update(ChoferActualiza);
        this._context.SaveChanges(); */

        /*Borrar*/
        /* Drivers ChoferBorrado = this._context.Driver.Where(c => c.Id == new Guid("2973493E-0108-451C-7B0E-08DC89DDF5A1")).First();
        
        this._context.Driver.Remove(ChoferBorrado);
        this._context.SaveChanges(); */

        List<DriverModel> list = _context.Driver.Select(d => new DriverModel
            {
                Id = d.Id,
                Nombre = d.Nombre,
                Telefono = d.Telefono,
                NumLicencia = d.NumLicencia
            }).ToList();

            return View(list);
    }

    public IActionResult DriversAdd()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DriverSave(DriverModel model)
    {
        if(ModelState.IsValid)
        {
           var Chofer = new Drivers();
            Chofer.Id = Guid.NewGuid();
            Chofer.Nombre = model.Nombre;
            Chofer.Telefono = model.Telefono;
            Chofer.NumLicencia = model.NumLicencia;
        
            this._context.Driver.Add(Chofer);
            this._context.SaveChanges();

            return RedirectToAction("DriversList", "Drivers");
        }

        return RedirectToAction("DriversAdd", "Drivers");
    }

    public IActionResult DriverShowAndEdit(Guid Id)
    {
        Drivers? drivers = _context.Driver.Where(d => d.Id == Id).FirstOrDefault();
         if (drivers == null)
        {
            return RedirectToAction("DriversList", "Drivers");
        }

        DriverModel model = new DriverModel();
        model.Id = drivers.Id;
        model.Nombre = drivers.Nombre;
        model.Telefono = drivers.Telefono;
        model.NumLicencia = drivers.NumLicencia;

        return View(model);
    }

    [HttpPost]
     public IActionResult DriverEdit(DriverModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var driver = _context.Driver.Find(model.Id);
        if (driver == null)
        {
            return NotFound();
        }

        driver.Nombre = model.Nombre;
        driver.Telefono = model.Telefono;
        driver.NumLicencia = model.NumLicencia;

        _context.Driver.Update(driver);
        _context.SaveChanges();

        return View("DriversList");
    }
 
     public IActionResult DriverShowToDeleted(Guid Id)
    {
         Drivers? drivers = _context.Driver.Where(d => d.Id == Id).FirstOrDefault();
         if (drivers == null)
        {
            return RedirectToAction("DriversList", "Drivers");
        }

        DriverModel model = new DriverModel();
        model.Id = drivers.Id;
        model.Nombre = drivers.Nombre;
        model.Telefono = drivers.Telefono;
        model.NumLicencia = drivers.NumLicencia;

        return View(model);
        
    }

    public IActionResult DriverDeleted(DriverModel model)
    {
        if (!ModelState.IsValid)
        {
            var driver = _context.Driver.Find(model.Id);
        if (driver == null)
        {
            return NotFound();
        }

        driver.Nombre = model.Nombre;
        driver.Telefono = model.Telefono;
        driver.NumLicencia = model.NumLicencia;

        _context.Driver.Remove(driver);
        _context.SaveChanges();

        return RedirectToAction("DriversList");
        }

        return View(model);
        
    }
}

