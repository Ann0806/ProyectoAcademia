using Servicios_Academia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Servicios_Academia.Clases
{
    public class clsMaterias { 
        
        AcademiaDeSistemasEntities sistemasdb = new AcademiaDeSistemasEntities();
        public Materia materia { get; set; }

        public string Insertar()
        {
            try
            {
                sistemasdb.Materias.Add(materia);
                sistemasdb.SaveChanges();
                return "Se ingreso correctamente la materia: " + materia.Nombre_materia;
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
                sistemasdb.Materias.AddOrUpdate(materia);
                sistemasdb.SaveChanges();
                return "Se actualizó correctamente la materia: " + materia.Nombre_materia;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }//fin metodo insertar
        public Materia Consultar(int ID_materia)
        {

            return sistemasdb.Materias.FirstOrDefault(e => e.ID_materia == ID_materia);

        }//fin consultar


        //CONSULTAR LISTA DE Profesores
        public List<Materia> ConsultarTodos()
        {
            return sistemasdb.Materias.ToList();
        }//fin consultar


        //ELIMINAR profesor
        public string Eliminar()
        {
            Materia _materia = Consultar(materia.ID_materia);
            sistemasdb.Materias.Remove(_materia);//de la base de datos se borra el objeto
            sistemasdb.SaveChanges();
            return "La materia con ID:" + materia.ID_materia + "ha sido removido con exito";

        }//fin eliminar 
    }
}