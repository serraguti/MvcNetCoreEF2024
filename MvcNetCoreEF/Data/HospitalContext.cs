using Microsoft.EntityFrameworkCore;
using MvcNetCoreEF.Models;

namespace MvcNetCoreEF.Data
{
    public class HospitalContext: DbContext
    {
        //TENDREMOS UN CONSTRUCTOR QUE RECIBIRA LAS OPCIONES DE 
        //INICIO Y CONEXION DE LA BASE DE DATOS
        //DICHAS OPCIONES DEBEN SER ENVIADAS A LA CLASE BASE
        public HospitalContext(DbContextOptions<HospitalContext> options)
            :base(options)
        { }

        //POR CADA MODEL NECESITAMOS UNA COLECCION DbSet QUE SERA LA QUE 
        //UTILIZAREMOS PARA LAS CONSULTAS LINQ
        public DbSet<Hospital> Hospitales { get; set; }
    }
}
