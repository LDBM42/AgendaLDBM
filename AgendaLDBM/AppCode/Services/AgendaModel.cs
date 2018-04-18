using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace AgendaLDBM.Services
{
    public class AgendaModel : EntityTypeConfiguration<AgendaEntidad>
    {
        public AgendaModel()
        {
            HasKey(t => t.Id); //primary key

            //propiedades que pasaran la info a la base de datos
            Property(t => t.Nombre).HasMaxLength(100).IsRequired();
            Property(t => t.Apellido).HasMaxLength(100).IsOptional();
            Property(t => t.Télefono).HasMaxLength(15).IsRequired();
            Property(t => t.Notas).IsOptional();

            //mapeamos estas propiedades a la tabla 'Contactos'
            ToTable("Contactos");
        }
    }
}