using CleanArchitecture.Dav.Domain.Livres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Dav.Infrastructure.DbsContext.Livres;

public class LivreEntityTypeConfiguration : IEntityTypeConfiguration<Livre>
{
    public void Configure(EntityTypeBuilder<Livre> builder)
    {
        builder.HasOne(c => c.Emprunt)
            .WithOne()
            .HasForeignKey<Emprunt>(x => x.IdLivre);

        builder.Navigation(e => e.Emprunt)
            .AutoInclude();
    }
}
