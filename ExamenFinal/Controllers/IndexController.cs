using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ExamenFinal.Models;
namespace ExamenFinal.Controllers
{
    public class IndexController : Controller
    {

        ValuesController bd = new ValuesController();
        public ActionResult Listado1()
        {


            return View(bd.GetListado1());
        }

        public ActionResult Agregar1()
        {

            ViewBag.pais = new SelectList(bd.GetListaPais(), "idpais", "nombrepais");


            return View(new Clientes());

        }

        [HttpPost]
        public ActionResult Agregar1(Clientes reg)
        {
            if (!ModelState.IsValid)
            {
                return View(reg);
            }

            ViewBag.pais = new SelectList(bd.GetListaPais(), "idpais", "nombrepais", reg.idpais);

            ViewBag.mensaje = bd.AgregarCliente(reg);

            return RedirectToAction("Listado1");

        }


        public ActionResult Actualizar1(string id)
        {
            var reg = bd.GetListadoCliente().Where(x => x.idcliente == id).FirstOrDefault();
            if (reg == null) RedirectToAction("Listado1");

            ViewBag.pais = new SelectList(bd.GetPaises().ToList(), "idpais", "nombrepais", reg.idpais);

            return View(reg);

        }

        [HttpPost]
        public ActionResult Actualizar1(Clientes reg)
        {
            if (!ModelState.IsValid)
            {
                return View(reg);
            }

            ViewBag.pais = new SelectList(bd.GetPaises().ToList(), "idpais", "nombrepais", reg.idpais);
            ViewBag.mensaje = bd.ActualizarCliente(reg);

            return RedirectToAction("Listado1");

        }
































        // GET: Index
        public ActionResult Listado()
        {


            return View(bd.GetListado());
        }

        public ActionResult Agregar() {

            ViewBag.pais = new SelectList(bd.GetPaises().ToList(), "idpais", "nombrepais");


            return View(new tb_clientes());

        }

        [HttpPost]
        public ActionResult Agregar(tb_clientes reg)
        {
            if (!ModelState.IsValid) {
                return View(reg);
            }

            ViewBag.pais = new SelectList(bd.GetPaises().ToList(), "idpais", "nombrepais",reg.idpais);

         ViewBag.mensaje=bd.Agregar(reg);

            return RedirectToAction("Listado");

        }


        public ActionResult Actualizar(string id)
        {
            var reg = bd.GetCliente(id);
            if (reg == null) RedirectToAction("Index");

            ViewBag.pais = new SelectList(bd.GetPaises().ToList(), "idpais", "nombrepais", reg.idpais);
            
            return View(reg);

        }

        [HttpPost]
        public ActionResult Actualizar(tb_clientes reg)
        {
            if (!ModelState.IsValid)
            {
                return View(reg);
            }

            ViewBag.pais = new SelectList(bd.GetPaises().ToList(), "idpais", "nombrepais", reg.idpais);
            ViewBag.mensaje = bd.Actualizar(reg);

            return RedirectToAction("Listado");

        }






    }
}