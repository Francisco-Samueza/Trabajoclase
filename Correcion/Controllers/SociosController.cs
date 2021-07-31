using Clasescorreccion.Clasescontrol;
using Correcion.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correcion.Controllers
{
    public class SociosController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public SociosController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: SociosController
        public ActionResult Index()
        {
            List<Socio> lstsocio = new List<Socio>();
            lstsocio = _dbContext.Socio.ToList();
            return View(lstsocio);
        }

        // GET: SociosController/Details/5
        public ActionResult Details(string id)
        {
            Socio socio = _dbContext.Socio.Where(s => s.Cedula == id).FirstOrDefault();
            return View(socio);
        }

        // GET: SociosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SociosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Socio socio)
        {
            try
            {
                socio.Estado = 1;
                _dbContext.Add(socio);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(socio);
            }
        }

        // GET: SociosController/Edit/5
        public ActionResult Edit(string id)
        {
            Socio socio= _dbContext.Socio.Where(x => x.Cedula == id).FirstOrDefault();
            return View(socio);
        }

        // POST: SociosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Socio socio)
        {
            if(id!=socio.Cedula)
            {
                return RedirectToAction("Index");
            }
            try
            {
                    _dbContext.Update(socio);
                    _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(socio);
            }
        }
        public ActionResult Activar(string id)
        {
            Socio socio = _dbContext.Socio.Where(x => x.Cedula == id).FirstOrDefault();
            socio.Estado = 1;
            _dbContext.Update(socio);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Desactivar(string id)
        {
            Socio socio = _dbContext.Socio.Where(x => x.Cedula == id).FirstOrDefault();
            socio.Estado = 0;
            _dbContext.Update(socio);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
