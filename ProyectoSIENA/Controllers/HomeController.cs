using ProyectoSIENA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSIENA.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            Usuario usu = new Usuario
            {
                Documento = long.Parse(collection["documento"].ToString()),
                Tipodoc = collection["tipodoc"].ToString(),
                Nombre = collection["nombre"].ToString(),
                Celular = collection["celular"].ToString(),
                Email = collection["email"].ToString(),
                Genero = collection["genero"].ToString(),
                Aprendiz = collection["aprendiz"].ToString(),
                Egresado = collection["egresado"].ToString(),
                AreaFormacion = collection["areaformacion"].ToString(),
                FechaEgresado = collection["fechaegresado"].ToString(),
                Direccion = collection["direccion"].ToString(),
                Barrio = collection["barrio"].ToString(),
                Ciudad = collection["ciudad"].ToString(),
                Departamento = collection["departamento"].ToString(),
                FechaRegistro = collection["fecharegistro"].ToString()
            };
            ma.Insertar(usu);
            return RedirectToAction("Index");
        }

        public ActionResult BuscarTodos()
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            return View(ma.RecuperarTodos());
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            Usuario usu = ma.Recuperar(id);
            return View(usu);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            Usuario usu = new Usuario
            {
                Id = id,
                Documento = int.Parse(collection["documento"].ToString()),
                Tipodoc = collection["tipodoc"].ToString(),
                Nombre = collection["nombre"].ToString(),
                Celular = collection["celular"].ToString(),
                Email = collection["email"].ToString(),
                Genero = collection["genero"].ToString(),
                Aprendiz = collection["aprendiz"].ToString(),
                Egresado = collection["egresado"].ToString(),
                AreaFormacion = collection["areaformacion"].ToString(),
                FechaEgresado = collection["fechaegresado"].ToString(),
                Direccion = collection["direccion"].ToString(),
                Barrio = collection["barrio"].ToString(),
                Ciudad = collection["ciudad"].ToString(),
                Departamento = collection["departamento"].ToString(),
                FechaRegistro = collection["fecharegistro"].ToString()
            };
            ma.Modificar(usu);
            return RedirectToAction("Index");
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            Usuario usu = ma.RecuperarPorDocumento(id);
            return View(usu);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            ma.Borrar(id);
            return RedirectToAction("Index");
        }
    }
}
