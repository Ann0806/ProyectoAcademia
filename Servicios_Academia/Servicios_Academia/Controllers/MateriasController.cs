using Servicios_Academia.Clases;
using Servicios_Academia.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Servicios_Academia.Controllers
{
    [EnableCors(origins: "http://localhost:63452", headers: "*", methods: "*")]
    public class MateriasController : ApiController
    {
        // GET api/<controller>
        public List<Materia> Get()
        {
            clsMaterias materias = new clsMaterias();
            return materias.ConsultarTodos();
        }

        // GET api/<controller>/5
        public Materia Get(int ID_materia)
        {
            clsMaterias materias = new clsMaterias();
            return materias.Consultar(ID_materia);
        }


        // POST api/<controller>
        public string Post([FromBody] Materia materia)
        {
                clsMaterias materias = new clsMaterias();
                materias.materia=materia;
                return materias.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] Materia materia)
        {
            clsMaterias materias = new clsMaterias();
            materias.materia = materia;
            return materias.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete([FromBody] Materia materia)
        {
            clsMaterias materias = new clsMaterias();
            materias.materia = materia;
            return materias.Eliminar();
        }
    }
}