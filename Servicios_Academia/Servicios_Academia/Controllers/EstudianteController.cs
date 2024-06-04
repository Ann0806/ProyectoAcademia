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
    [RoutePrefix("api/Estudiante")]
    public class EstudianteController : ApiController
    {

        [HttpGet]
        [Route("")]
        public Estudiante Get(int Documento)
        {
            clsEstudiante _estudiante = new clsEstudiante();
            return _estudiante.Consultar(Documento);
        }

        [HttpPost]
        [Route("")]
        public string Post([FromBody] Estudiante estudiantes)
        {
            clsEstudiante _estudiante = new clsEstudiante();
            _estudiante.estudiante = estudiantes;
            return _estudiante.Insertar();
        }

        [HttpPut]
        [Route("")]
        public string Put([FromBody] Estudiante estudiantes)
        {
            clsEstudiante _estudiante = new clsEstudiante();
            _estudiante.estudiante = estudiantes;
            return _estudiante.Actualizar();
        }

        [HttpDelete]
        [Route("")]
        public string Delete([FromBody] Estudiante estudiantes)
        {
            clsEstudiante _estudiante = new clsEstudiante();
            _estudiante.estudiante = estudiantes;
            return _estudiante.Eliminar();
        }

        [HttpGet]
        [Route("ListarEstudiantes")]
        public IQueryable ListarEstudiantes()
        {
            clsEstudiante _estudiante = new clsEstudiante();
            return _estudiante.ListarEstudiantes();
        }

    
    }
}
