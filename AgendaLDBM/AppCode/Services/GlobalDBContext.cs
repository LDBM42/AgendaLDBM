using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AgendaLDBM.Services
{
    public class GlobalDBContext : DbContext
    {
        public GlobalDBContext() : base("LDBMAgenda")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AgendaModel());
        }

        // dependiendo de si vamos a leer o a escribir, se desactiva o
        //active el trackChanges, para mejorar la velocidad y el rendimiento.
        public IQueryable<AgendaEntidad> Contactos(bool trackChanges = false)
        {
            IQueryable<AgendaEntidad> query = this.Set<AgendaEntidad>();

            if (!trackChanges) // si es igual a false
            {
                query = query.AsNoTracking();
            }

            return query;
        }

        public System.Data.Entity.DbSet<AgendaLDBM.Services.AgendaEntidad> AgendaEntidads { get; set; }
    }
}