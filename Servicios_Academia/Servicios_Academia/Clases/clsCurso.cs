using Servicios_Academia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Servicios_Academia.Clases
{
    public class clsCurso { 
        
        AcademiaDeSistemasEntities sistemasdb = new AcademiaDeSistemasEntities();
        public Curso curso { get; set; }

        public string Insertar()
        {
            try
            {
                sistemasdb.Cursos.Add(curso);
                sistemasdb.SaveChanges();
                return "Se ingreso correctamente el curso: " + curso.Nombre_curso;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string Actualizar()
        {
            try
            {
                sistemasdb.Cursos.AddOrUpdate(curso);
                sistemasdb.SaveChanges();
                return "Se actualizó correctamente el curso: " + curso.Nombre_curso;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public Curso Consultar(int ID_curso)
        {

            return sistemasdb.Cursos.FirstOrDefault(e => e.ID_curso == ID_curso);

        }
        public List<Curso> ConsultarTodos()
        {
            return sistemasdb.Cursos.ToList();
        }
        public string Eliminar()
        {
            Curso _curso = Consultar(curso.ID_curso);
            sistemasdb.Cursos.Remove(curso);//de la base de datos se borra el objeto
            sistemasdb.SaveChanges();
            return "El curso con ID:" + curso.ID_curso + "ha sido removido con exito";

        }

        public IQueryable ListarCurso()
        {
            return from M in sistemasdb.Set<Curso>()
                   select new
                   {
                       Codigo = M.ID_curso,
                       Nombre = M.Nombre_curso
                   };
        }

    }
}