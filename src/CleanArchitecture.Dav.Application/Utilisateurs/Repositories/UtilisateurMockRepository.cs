using CleanArchitecture.Dav.Domain.Utilisateurs.Entities;
using CleanArchitecture.Dav.Domain.Utilisateurs.Repositories;

namespace CleanArchitecture.Dav.Application.Utilisateurs.Repositories;

public class UtilisateurMockRepository : IUtilisateurRepository
{
    List<Utilisateur> _utilisateurs = new List<Utilisateur>();

    public UtilisateurMockRepository()
    {
        var johnDoe = new Utilisateur
        {
            Id = Guid.Parse("51288882-4750-467c-bf39-2b10caf120c4"),
            Nom = "John Doe",
            Prenom = "Doe",
            Email = "john.doe@example.com",
        };
        
        var janeDoe = new Utilisateur
        {
            Id = Guid.Parse("6b60950a-6365-4d06-882f-8260c01c4140"),
            Nom = "Jane Doe",
            Prenom = "Doe",
            Email = "jane.doe@example.com",
        };
        
        _utilisateurs.Add(johnDoe);
        _utilisateurs.Add(janeDoe);
    }
    
    public Task<Utilisateur?> GetById(Guid id)
    {
        var utilisateur = _utilisateurs.SingleOrDefault(x => x.Id == id);
        return Task.FromResult(utilisateur);
    }

    public Task<List<Utilisateur>> Get()
    {
        return Task.FromResult(_utilisateurs);
    }

    public Task<Utilisateur> Create(Utilisateur entity)
    {
        _utilisateurs.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<Utilisateur> Update(Utilisateur entity)
    {
        var index = _utilisateurs.FindIndex(x => x.Id == entity.Id);
        _utilisateurs[index] = entity;
        return Task.FromResult(entity);
    }
}