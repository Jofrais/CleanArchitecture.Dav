using CleanArchitecture.Dav.Domain.Livres.Entities;
using CleanArchitecture.Dav.Domain.Utilisateurs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Dav.Infrastructure.DbsContext.Livres;

public class EmpruntTypeConfiguration : IEntityTypeConfiguration<Emprunt>
{
    public void Configure(EntityTypeBuilder<Emprunt> builder)
    {
        builder.HasOne<Utilisateur>()
            .WithMany()
            .HasForeignKey(x => x.IdUtilisateur);
    }
}
