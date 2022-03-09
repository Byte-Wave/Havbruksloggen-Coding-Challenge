using Havbruksloggen_Coding_Challenge.BoatAndCrewMemberManager.Models.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Database.Mappings
{
    public class BoatMap : IEntityTypeConfiguration<BoatEntity>
    {
        public void Configure(EntityTypeBuilder<BoatEntity> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("boat_id")
                .HasColumnType("UUID")
                .ValueGeneratedOnAdd();

            builder.HasKey(c => c.Id)
                .HasName("PK_BoatId");

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(c => c.Producer)
                .HasColumnName("producer")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(c => c.BuildNumber)
                .HasColumnName("build_number")
                .HasColumnType("int");

            builder.Property(c => c.MaximumLength)
                .HasColumnName("maximum_length")
                .HasColumnType("float");

            builder.Property(c => c.MaximumWidth)
                .HasColumnName("maximum_width")
                .HasColumnType("float");

            builder.Property(c => c.PicturesPath)
                .HasColumnName("pictures_path")
                .HasColumnType("varchar(250)")
                .HasMaxLength(250);
        }
    }
}
