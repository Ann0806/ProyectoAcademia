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
        public IQueryable ListarEstudiantes()
        {
            return from E in dbAcademia.Set<Estudiante>()
                   orderby E.Nombre
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEdit\" class=\"btn-block btn-sm btn-danger\" " +
                                "onclick=\"Editar('" + E.Documento + "', '" + E.Nombre + "', '" + E.PrimerApellido + "', '" + E.SegundoApellido +
                                "', '" + E.Fecha_Nacimiento + "', '" + E.Telefono + "', '" + E.Correo_electronico + "')\">EDITAR</button>",
                       Documento = E.Documento,
                       Nombre = E.Nombre,
                       PrimerApellido = E.PrimerApellido,
                       SegundoApellido = E.SegundoApellido,
                       Fecha_Nacimiento = E.Fecha_Nacimiento,
                       Telefono = E.Telefono,
                       Correo = E.Correo_electronico
                   };
        }
    }
}