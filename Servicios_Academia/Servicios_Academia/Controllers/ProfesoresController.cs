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
    [RoutePrefix("api/Profesores")]
    public class ProfesoresController : ApiController
    {
        [HttpGet]
        [Route("")]
        public List<Profesore> Get()
        {
            clsProfesor profe = new clsProfesor();
            return profe.ConsultarTodos();
        }

        [HttpGet]
        [Route("")]
        public Profesore Get(int Documento)
        {
            clsProfesor profe = new clsProfesor();
            return profe.Consultar(Documento);
        }

        [HttpPost]
        [Route("")]
        public string Post([FromBody] Profesore profesor)
        {
            clsProfesor profe = new clsProfesor();
            profe.profesor = profesor;
            return profe.Insertar();
        }

        [HttpPut]
        [Route("")]
        public string Put([FromBody] Profesore profesor)
        {
            clsProfesor profe = new clsProfesor();
            profe.profesor = profesor;
            return profe.Actualizar();
        }

        [HttpDelete]
        [Route("")]
        public string Delete([FromBody] Profesore profesor)
        {
            clsProfesor profe = new clsProfesor();
            profe.profesor = profesor;
            return profe.Eliminar ();
        }

        [HttpGet]
        [Route("ListarProfesores")]
        public IQueryable ListarProfesores()
        {
            clsProfesor _profesor = new clsProfesor();
            return _profesor.ListarProfesores();
        }

        [HttpGet]
        [Route("LlenarCombo")]
        public IQueryable LlenarCombo(int ID_curso)
        {
            clsProfesor _profesor = new clsProfesor();
            return _profesor.LlenarCombo(ID_curso);
        }
    }
}