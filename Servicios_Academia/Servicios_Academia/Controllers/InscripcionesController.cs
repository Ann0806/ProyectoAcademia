using Servicios_Academia.Clases;
using Servicios_Academia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Servicios_Academia.Controllers
{
    [EnableCors(origins: "http://localhost:63452", headers: "*", methods: "*")]
    [RoutePrefix("api/Inscripciones")]
    public class InscripcionesController : ApiController
    {
        [HttpPost]
        [Route("GrabarInscripciones")]
        public string GrabarInscripciones(Inscripcione inscripcion)
        {
            clsInscripciones _ins = new clsInscripciones();
            _ins.inscripcione = inscripcion;
            return _ins.GrabarInscripciones();
        }
        [HttpPost]
        [Route("GrabarDetalle")]
        public string GrabarDetalle(DetalleInscripcion detalleInscripcion)
        {
            clsInscripciones _ins = new clsInscripciones();
            _ins.detalleInscripcion = detalleInscripcion;
            return _ins.GrabarDetalle();
        }

        [HttpGet]
        [Route("ListarInscripcion")]
        public IQueryable ListarInscripcion()
        {
            clsInscripciones _ins = new clsInscripciones();
            return _ins.ListarInscripcion();
        }

        [HttpDelete]
        [Route("EliminarInscripcion")]
        public string EliminarInscripcion(int ID_inscripcion)
        {
            clsInscripciones _ins = new clsInscripciones();
            return _ins.Eliminar(ID_inscripcion);

        }

    }
}
