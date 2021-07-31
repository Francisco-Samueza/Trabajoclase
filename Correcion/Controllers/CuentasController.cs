using Clasescorreccion.Clasescontrol;
using Correcion.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correcion.Controllers
{
    public class CuentasController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CuentasController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: CuentasController
        public ActionResult Index()
        {
            List<Cuenta> lstcuenta = new List<Cuenta>();
            lstcuenta = _dbContext.Cuenta.ToList();
            return View(lstcuenta);
        }

        // GET: CuentasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CuentasController/Create
        public ActionResult Create()
        {
            ViewData["CodigoSocio"] = new SelectList(_dbContext.Socio.Where(e=>e.Estado==1).ToList(), "Cedula", "Cedula");
            return View();
        }

        // POST: CuentasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cuenta cuenta)
        {
            try
            {
                cuenta.Estado = 1;
                _dbContext.Add(cuenta);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cuenta);
            }
        }

        // GET: CuentasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CuentasController/Edit/5
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

        // GET: CuentasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CuentasController/Delete/5
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
}
