using Servicios_Academia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_Academia.Clases
{
    public class clsInscripciones
    {

        AcademiaDeSistemasEntities dbAcademia = new AcademiaDeSistemasEntities();

        public Inscripcione inscripcione { get; set; }
        public DetalleInscripcion detalleInscripcion { get; set; }


        public string GrabarInscripciones()
        {
            try
            {
                inscripcione.ID_inscripcion = CalcularNumeroInscripcion();
                inscripcione.Fecha_inscripcion = DateTime.Now;
                dbAcademia.Inscripciones.Add(inscripcione);
                dbAcademia.SaveChanges();
                return inscripcione.ID_inscripcion +"";
            }
            catch (Exception ex)
            {
                return "Error al grabar la inscripción: " + ex.Message;
            }
        }

        private int CalcularNumeroInscripcion()
        {
            return dbAcademia.Inscripciones.Select(f => f.ID_inscripcion).DefaultIfEmpty(0).Max() + 1;
        }
        
        public string GrabarDetalle()
        {
            try
            {
                dbAcademia.DetalleInscripcions.Add(detalleInscripcion);
                dbAcademia.SaveChanges();
                return detalleInscripcion.ID_inscripcion.ToString();
            }
            catch (Exception ex)
            {
                // Log the exception
                return "Error al grabar el detalle de inscripción: " + ex.Message;
            }
        }

        public IQueryable ListarInscripcion()
        {
            return from I in dbAcademia.Inscripciones
                   join E in dbAcademia.Estudiantes
                   on I.Documento_estudiante equals E.Documento
                   join C in dbAcademia.Cursos
                   on I.ID_curso equals C.ID_curso
                   select new
                   {
                       Eliminar = "<button type=\"button\" id=\"btnEdit\" class=\"btn-block btn-sm btn-danger\" " +
                                "onclick=\"Eliminar('" + I.ID_inscripcion + "', '" + E.Documento + "', '" + E.Nombre + "', '" + E.PrimerApellido + "', '" + E.SegundoApellido +
                                "', '" + C.Nombre_curso + "', '" + C.Duracion + "', '" + C.Costo + "', '" + I.Fecha_inscripcion+ "')\">Eliminar</button>",
                       ID_inscripcion = I.ID_inscripcion,
                       Documento = E.Documento,
                       Estudiante = E.Nombre +" "+E.PrimerApellido+" "+E.SegundoApellido,
                       Curso = C.Nombre_curso,
                       Duracion = C.Duracion,
                       Costo = C.Costo,
                       Fecha_inscripcion = I.Fecha_inscripcion, 
                   };
        }
        public Inscripcione Consultar(int id)
        {
            return dbAcademia.Inscripciones.FirstOrDefault(p => p.ID_inscripcion == id);
        }
        
        public string Eliminar(int ID_inscripcion)
        {
            
            Inscripcione _Detalle = dbAcademia.Inscripciones.FirstOrDefault(d => d.ID_inscripcion == ID_inscripcion);
            DetalleInscripcion _s = dbAcademia.DetalleInscripcions.FirstOrDefault(a => a.ID_inscripcion == ID_inscripcion);
            dbAcademia.Inscripciones.Remove(_Detalle);
            dbAcademia.DetalleInscripcions.Remove(_s); 
            dbAcademia.SaveChanges();
            return "Se eliminó la inscripcion";        
        }

    }
}