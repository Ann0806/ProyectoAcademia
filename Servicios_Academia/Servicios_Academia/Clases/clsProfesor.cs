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
                return "Se ingreso correctamente el profesor: " + profesor.Nombre;
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

        }//fin consultar


        //CONSULTAR LISTA DE Profesores
        public List<Profesore> ConsultarTodos()
        {
            return sistemasdb.Profesores.ToList();
        }//fin consultar


        //ELIMINAR profesor
        public string Eliminar()
        {
            Profesore _profesor = Consultar(profesor.Documento);//un objeto de tipo profesor guardara el objeto que me retorne
            //el metodo consultar por profesorID
            sistemasdb.Profesores.Remove(_profesor);//de la base de datos se borra el objeto
            sistemasdb.SaveChanges();
            return "El profesor con ID:" + _profesor.Documento + "ha sido removido con éxito";

        }//fin eliminar 
    }
}