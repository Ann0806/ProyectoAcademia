using Servicios_Academia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;

namespace Servicios_Academia.Clases
{
    public class clsEstudiante
    {

        AcademiaDeSistemasEntities dbAcademia = new AcademiaDeSistemasEntities();

        public Estudiante estudiante { get; set; }

        public string Insertar()
        {
            try
            {       
                dbAcademia.Estudiantes.Add(estudiante);
                dbAcademia.SaveChanges();
                return "El estudiante " + estudiante.Nombre + " " + estudiante.PrimerApellido + " se grabó correctamente";
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
                dbAcademia.Estudiantes.AddOrUpdate(estudiante);
                dbAcademia.SaveChanges();
                return "El estudiante " + estudiante.Nombre + " " + estudiante.PrimerApellido + " se actualizó correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Estudiante Consultar(int Documento)
        {
            return dbAcademia.Estudiantes.FirstOrDefault(p => p.Documento == Documento);
        }

        public List<Estudiante> ConsultarTodos()
        {
            return dbAcademia.Estudiantes.ToList();
        }
        public IQueryable ListarEstudiantes()
        {
            return from I in dbAcademia.Set<Inscripcione>()
                   join E in dbAcademia.Set<Estudiante>()
                   on I.Documento_estudiante equals E.Documento
                   orderby I.Estudiante, E.Nombre
                   select new
                   {
                        IDInscripcion = I.ID_inscripcion,
                        Documento = I.Documento_estudiante,
                        Nombre = E.Nombre,
                        Apellido = E.PrimerApellido,
                        Correo = E.Correo_electronico,
                   };
        }

        public string Eliminar()
        {
            Estudiante _Estudiante = Consultar(estudiante.Documento);
        
            if (_Estudiante != null)
            {
                dbAcademia.Estudiantes.Remove(_Estudiante);
                dbAcademia.SaveChanges();
                return "El estudiante con el ID " + _Estudiante.Documento + " fue eliminado exitosamente";
            }
            else
            {
                return "No se encontró ningún estudiante con el Documento " + estudiante.Documento;
            }
        }
    }
}