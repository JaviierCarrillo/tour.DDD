using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Generico;

namespace tour.DDD.Infraestructure.Configuration
{
    public class StroredEventConfig : IEntityTypeConfiguration<BodegaEvento>
    {
        public void Configure(EntityTypeBuilder<BodegaEvento> builder)
        {
            builder.ToTable("EventosAlmacenados");
            builder.HasKey(p => p.AlmacenadoId);
        }

    }
}
