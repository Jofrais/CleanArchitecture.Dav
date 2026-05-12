using CleanArchitecture.Dav.Domain.Livres.Entities;
using CleanArchitecture.Dav.Domain.Livres.Repositories;

namespace CleanArchitecture.Dav.Application.Livres.Repositories;

public class LivreMockRepository : ILivreRepository
{
    private List<Livre> livres = new();
    
    public LivreMockRepository()
    {
        Livre livre = new Livre()
        {
            Id = Guid.Parse("7410eeee-4c9a-4b7e-90ed-0b0207a82d33"),
            Titre = "Le petit prince",
            Auteur = "",
            ISBN = "978-2-8462-8087-7"
        };

        livres.Add(livre);
    }
    
    public Task<Livre?> GetById(Guid id)
    {
        return Task.FromResult(livres.SingleOrDefault(x => x.Id == id));
    }

    public Task<List<Livre>> Get()
    {
        return Task.FromResult(livres);
    }

    public Task<Livre> Create(Livre entity)
    {
        if(livres.Any(x => x.Id == entity.Id))
            throw new InvalidOperationException("Le livre existe déjà");
        
        livres.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<Livre> Update(Livre entity)
    {
        var index = livres.FindIndex(x => x.Id == entity.Id);
        livres[index] = entity;
        return Task.FromResult(entity);
    }
}