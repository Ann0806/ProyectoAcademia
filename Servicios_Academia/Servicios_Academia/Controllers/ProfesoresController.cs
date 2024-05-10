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
    public class ProfesoresController : ApiController
    {
        
        // GET api/<controller>
        public List<Profesore> Get()
        {
            clsProfesor profe = new clsProfesor();
            return profe.ConsultarTodos();
        }

        // GET api/<controller>/5
        public Profesore Get(int ID_profesor)
        {
            clsProfesor profe = new clsProfesor();
            return profe.Consultar(ID_profesor);
        }

        // POST api/<controller>
        public string Post([FromBody] Profesore profesor)
        {
            clsProfesor profe = new clsProfesor();
            profe.profesor = profesor;
            return profe.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] Profesore profesor)
        {
            clsProfesor profe = new clsProfesor();
            profe.profesor = profesor;
            return profe.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete([FromBody] Profesore profesor)
        {
            clsProfesor profe = new clsProfesor();
            profe.profesor = profesor;
            return profe.Eliminar ();
        }
    }
}