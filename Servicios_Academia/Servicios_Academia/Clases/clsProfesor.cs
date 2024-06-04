using Servicios_Academia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Servicios_Academia.Clases
{
    public class clsProfesor
    {

        AcademiaDeSistemasEntities sistemasdb = new AcademiaDeSistemasEntities();
        public Profesore profesor { get; set; }

        public string Insertar()
        {
            try
            {
                sistemasdb.Profesores.Add(profesor);
                sistemasdb.SaveChanges();
                return "Se ingreso correctamente el profesor: " + profesor.Nombre + " " + profesor.PrimerApellido;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }//fin metodo insertar

        public string Actualizar()
        {
            try
            {
                sistemasdb.Profesores.AddOrUpdate(profesor);
                sistemasdb.SaveChanges();
                return "Se actualizó correctamente el profesor: " + profesor.Documento;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }//fin metodo insertar
        public Profesore Consultar(int Documento)
        {
            return sistemasdb.Profesores.FirstOrDefault(e => e.Documento == Documento);

        }
        public List<Profesore> ConsultarTodos()
        {
            return sistemasdb.Profesores.ToList();
        }

        public string Eliminar()
        {
            Profesore _profesor = Consultar(profesor.Documento);
            sistemasdb.Profesores.Remove(_profesor);
            sistemasdb.SaveChanges();
            return "El profesor con Documento " + _profesor.Documento + " ha sido removido con éxito";

        }

        public IQueryable ListarProfesores()
        {
            return from P in sistemasdb.Profesores
                   join C in sistemasdb.Cursos on P.ID_curso equals C.ID_curso
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEdit\" class=\"btn-block btn-sm btn-danger\" " +
                                "onclick=\"Editar('" + P.Documento + "', '" + P.Nombre + "', '" + P.PrimerApellido + "', '" + P.SegundoApellido +
                                "', '" + C.ID_curso + "', '" + P.Telefono + "', '" + P.Correo_electronico + "')\">EDITAR</button>",

                       Documento = P.Documento,
                       Nombre = P.Nombre,
                       PrimerApellido = P.PrimerApellido,
                       SegundoApellido = P.SegundoApellido,
                       Telefono = P.Telefono,
                       Correo = P.Correo_electronico,
                       Curso = C.Nombre_curso
                   };
        }

        public IQueryable LlenarCombo(int ID_curso)
        {
            return from P in sistemasdb.Set<Profesore>()
                   where P.ID_curso == ID_curso
                   select new
                   {
                       Codigo = P.Documento,
                       Nombre = P.Nombre +" "+P.PrimerApellido+" "+P.SegundoApellido 
                   };
        }

    }
}