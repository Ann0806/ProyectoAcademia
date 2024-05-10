using Servicios_Academia.Clases;
using Servicios_Academia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servicios_Academia.Controllers
{
    public class CursosController : ApiController
    {
        // GET api/<controller>
        public List<Curso> Get()
        {
            clsCursos _curso = new clsCursos();
            return _curso.ConsultarTodos();

        }

        // GET api/<controller>/5
        public Curso Get(int ID_curso)
        {
            clsCursos _clsCurso = new clsCursos();
            return _clsCurso.Consultar(ID_curso);
        }

        // POST api/<controller>
        public string Post([FromBody] Curso curso)
        {
            clsCursos _curso = new clsCursos();
            _curso.curso = curso;
            return _curso.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] Curso curso)
        {
            clsCursos _curso = new clsCursos();
            _curso.curso = curso;
            return _curso.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete(Curso curso)
        {
            clsCursos _curso = new clsCursos();
            _curso.curso = curso;
            return _curso.Eliminar();
        }
    }
}