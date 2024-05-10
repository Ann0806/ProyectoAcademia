using Servicios_Academia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Servicios_Academia.Clases
{
    public class clsCursos
    {
        AcademiaDeSistemasEntities sistemasdb = new AcademiaDeSistemasEntities();
        public Curso curso { get; set; }

        public string Insertar()
        {
            try
            {
                sistemasdb.Cursos.Add(curso);
                sistemasdb.SaveChanges();
                return "Se ingreso correctamente el curso: " + curso.ID_curso;
            }
            catch (DbEntityValidationException ex)
            {
                return ex.Message;
            }

        }//fin metodo insertar

        public string Actualizar()
        {
            try
            {
                sistemasdb.Cursos.AddOrUpdate(curso);
                sistemasdb.SaveChanges();
                return "Se actualizó correctamente el curso: " + curso.ID_curso;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }//fin metodo insertar
        public Curso Consultar(int ID_curso)
        {

            return sistemasdb.Cursos.FirstOrDefault(e => e.ID_curso == ID_curso);

        }//fin consultar


        //CONSULTAR LISTA DE CURSOS
        public List<Curso> ConsultarTodos()
        {
            return sistemasdb.Cursos.ToList();
        }//fin consultar


        //ELIMINAR CURSO
        public string Eliminar()
        {
            Curso _curso = Consultar(curso.ID_curso);//un objeto de tipo Curso guardara el objeto qque me retorne
            //el metodo consultar por CursoID
            sistemasdb.Cursos.Remove(_curso);//de la base de datos se borra el objeto
            sistemasdb.SaveChanges();
            return "El curso con ID:" + _curso.ID_curso + "ha sido removido con exito";

        }//fin eliminar 
    }
}