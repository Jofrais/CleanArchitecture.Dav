using CleanArchitecture.Dav.Application.Livres.Dtos;
using CleanArchitecture.Dav.Application.Livres.Mappings;
using CleanArchitecture.Dav.Domain.Common.Exceptions;
using CleanArchitecture.Dav.Domain.Livres.Entities;
using CleanArchitecture.Dav.Domain.Livres.Repositories;
using CleanArchitecture.Dav.Domain.Utilisateurs.Entities;
using CleanArchitecture.Dav.Domain.Utilisateurs.Repositories;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Dav.Application.Livres.UseCases.Commands.Emprunter;

public interface IEmprunterLivreHandler
{
    Task<LivreDto> Handle(EmprunterLivreCommand command);
}

public class EmprunterLivreHandler : IEmprunterLivreHandler
{
    private readonly ILogger<EmprunterLivreHandler> _logger;
    private readonly IUtilisateurRepository _utilisateurRepository;
    private readonly ILivreRepository _livreRepository;

    public EmprunterLivreHandler(ILogger<EmprunterLivreHandler> logger, IUtilisateurRepository utilisateurRepository, ILivreRepository livreRepository)
    {
        _logger = logger;
        _utilisateurRepository = utilisateurRepository;
        _livreRepository = livreRepository;
    }

    public async Task<LivreDto> Handle(EmprunterLivreCommand command)
    {
        _logger.LogInformation("Emprunt du livre {IdLivre} par l'utilisateur {IdUtilisateur}.", command.IdLivre,
            command.IdUtilisateur);

        var livre = await _livreRepository.GetById(command.IdLivre)
                    ?? throw new EntityNotFoundException<Livre>(command.IdLivre);
        
        var utilisateur = await _utilisateurRepository.GetById(command.IdUtilisateur) 
            ?? throw new EntityNotFoundException<Utilisateur>(command.IdUtilisateur);
        
        livre.Emprunter(utilisateur.Id);
        
        await _livreRepository.Update(livre);

        return livre.ToDto();
    }
}