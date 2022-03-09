using Havbruksloggen_Coding_Challenge.BoatAndCrewMemberManager.Models.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Database.Mappings
{
    public class CrewMemberMap : IEntityTypeConfiguration<CrewMemberEntity>
    {
        public void Configure(EntityTypeBuilder<CrewMemberEntity> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("crew_member_id")
                .HasColumnType("UUID")
                .ValueGeneratedOnAdd();

            builder.HasKey(c => c.Id)
                .HasName("PK_CrewMemberId");

            builder.Property(c => c.BoatId)
                .HasColumnName("boat_id")
                .HasColumnType("UUID");

            builder.HasOne(c => c.Boat)
                .WithMany(c => c.CrewMembers)
                .HasForeignKey(c => c.BoatId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(c => c.Age)
                .HasColumnName("age")
                .HasColumnType("int");

            builder.Property(c => c.Email)
                .HasColumnName("pictures_path")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(c => c.Role)
                .HasColumnName("crew_role")
                .HasColumnType("int");

            builder.Property(c => c.CertifiedUntil)
                .HasColumnName("certified_until")
                .HasColumnType("date");

            builder.Property(c => c.PicturesPath)
                .HasColumnName("pictures_path")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

        }
    }
}
