using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MvcNetCoreEF.Data;
using MvcNetCoreEF.Models;

namespace MvcNetCoreEF.Repositories
{
    public class RepositoryHospital
    {
        //LA CLASE REPO SIEMPRE RECIBIRA EL CONTEXT 
        //MEDIANTE INYECCION DE DEPENDENCIAS
        private HospitalContext context;
        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public List<Hospital> GetHospitales()
        {
            var consulta = from datos in this.context.Hospitales
                           select datos;
            return consulta.ToList();
        }

        public Hospital FindHospital(int idHospital)
        {
            var consulta = from datos in this.context.Hospitales
                           where datos.IdHospital == idHospital
                           select datos;
            //PODRIA SER QUE NO ENCONTRASEMOS HOSPITAL POR EL ID
            //TENEMOS UN METODO QUE ES FirstOrDefault() QUE DEVUELVE 
            //EL PRIMER REGISTRO EL VALOR POR DEFECTO DEL MODEL
            return consulta.FirstOrDefault();
        }

        public void InsertHospital(int idHospital, string nombre, string direccion
            , string telefono, int camas)
        {
            //INSTANCIAR NUESTRO MODEL
            Hospital hospital = new Hospital();
            //ASIGNAMOS LAS PROPIEADES
            hospital.IdHospital = idHospital;
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.Camas = camas;
            //AÑADIMOS EL MODEL A NUESTRA COLECCION DbSet
            this.context.Hospitales.Add(hospital);
            //ALMACENAMOS LOS DATOS EN LA BASE DE DATOS
            this.context.SaveChanges();
        }

        public void DeleteHospital(int idHospital)
        {
            //BUSCAMOS EL MODEL HOSPITAL PARA ELIMINARLO
            Hospital hospital = this.FindHospital(idHospital);
            //ELIMINAMOS EL OBJETO DEL DbSet
            this.context.Hospitales.Remove(hospital);
            //ALMACENAMOS LOS CAMBIOS EN LA BASE DE DATOS
            this.context.SaveChanges();
        }

        public void UpdateHospital(int id, string nombre, 
            string direccion, string telefono, int camas)
        {
            //BUSCAMOS EL HOSPITAL POR SU ID
            Hospital hospital = this.FindHospital(id);
            //MODIFICAMOS SUS PROPIEDADES
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.Camas = camas;
            //DIRECTAMENTE MODIFICAMOS LA BASE DE DATOS
            this.context.SaveChanges();
        }
    }
}
