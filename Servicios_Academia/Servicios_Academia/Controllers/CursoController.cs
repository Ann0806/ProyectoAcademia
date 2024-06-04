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
    [RoutePrefix("api/Curso")]
    public class CursoController : ApiController
    {
        [HttpGet]
        [Route("Curso")]
        public List<Curso> Get()
        {
            clsCurso _curso = new clsCurso();
            return _curso.ConsultarTodos();
        }

        [HttpGet]
        [Route("")]
        // GET api/<controller>/5
        public Curso Get(int ID_curso)
        {
            clsCurso _curso = new clsCurso();
            return _curso.Consultar(ID_curso);
        }

        [HttpPost]
        [Route("")]
        // POST api/<controller>
        public string Post([FromBody] Curso curso)
        {
                clsCurso _curso = new clsCurso();
                _curso.curso= curso;
                return _curso.Insertar();
        }

        [HttpPut]
        [Route("")]
        public string Put([FromBody] Curso curso)
        {
            clsCurso materias = new clsCurso();
            materias.curso = curso;
            return materias.Actualizar();
        }

        [HttpDelete]
        [Route("")]
        public string Delete([FromBody] Curso curso)
        {
            clsCurso _curso = new clsCurso();
            _curso.curso = curso;
            return _curso.Eliminar();
        }

        [HttpGet]
        [Route("ListarCurso")]
        public IQueryable ListarCurso()
        {
            clsCurso _curso = new clsCurso();
            return _curso.ListarCurso();
        }
    }
}