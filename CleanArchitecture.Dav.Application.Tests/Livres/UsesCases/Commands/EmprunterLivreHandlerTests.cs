using AutoFixture;
using CleanArchitecture.Dav.Application.Livres.UseCases.Commands.Emprunter;
using CleanArchitecture.Dav.Application.Tests.Common.Extensions;
using CleanArchitecture.Dav.Domain.Common.Exceptions;
using CleanArchitecture.Dav.Domain.Livres.Entities;
using CleanArchitecture.Dav.Domain.Livres.Repositories;
using CleanArchitecture.Dav.Domain.Utilisateurs.Entities;
using CleanArchitecture.Dav.Domain.Utilisateurs.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace CleanArchitecture.Dav.Application.Tests.Livres.UsesCases.Commands;

/// <summary>
/// Voici un exemple de test pour la classe EmprunterLivreHandler.
/// Le nommage des tests est important pour faciliter la compréhension et la maintenance du code.
/// Il est important de mettre un DisplayName pour chaque test afin de faciliter la lecture des résultats des tests.
/// </summary>
public class EmprunterLivreHandlerTests : IAsyncLifetime
{
   private readonly Mock<IUtilisateurRepository> _utilisateurRepository;
   private readonly Mock<ILivreRepository> _livreRepository;
   private readonly Fixture _fixture = new();
   private readonly EmprunterLivreHandler _handler;

   public EmprunterLivreHandlerTests()
   {
      _utilisateurRepository = new();
      _livreRepository = new();
      _handler = new(Mock.Of<ILogger<EmprunterLivreHandler>>(),
         _utilisateurRepository.Object, 
         _livreRepository.Object);
   }
   
   [Fact(DisplayName = "Emprunter un livre doit retourner un LivreDto")]
   public async Task EmprunterLivre_ShouldReturnLivreDto()
   {
      var livre = _fixture.Build<Livre>()
         .Without(x => x.Emprunt)
         .Create();
      
      var utilisateur = _fixture.Create<Utilisateur>();
      
      var command = new EmprunterLivreCommand(livre.Id, utilisateur.Id);
      
      _utilisateurRepository.Setup(x => x.GetById(command.IdUtilisateur))
         .ReturnsAsync(utilisateur);
      
      _livreRepository.Setup(x => x.GetById(command.IdLivre))
         .ReturnsAsync(livre);
      
      // Ce mock est un peu spécial, on indique au return de nous retourner le livre passé en paramètre
      _livreRepository.Setup(x => x.Update(It.IsAny<Livre>()))
         .ReturnsAsync((Livre livreEnParametre) => livreEnParametre);
      
      var livreDto = await _handler.Handle(command, CancellationToken.None);
      Assert.NotNull(livreDto);
      
      Assert.Equal(livre.Id, livreDto.Id);
      
      Assert.NotNull(livreDto.Emprunt);
      Assert.Equal(utilisateur.Id, livreDto.Emprunt.IdUtilisateur);
   }
   
   [Fact(DisplayName = "Emprunter un livre avec livre inexistant doit lever une exception")]
   public async Task EmprunterLivre_WithNonExistingLivre_ShouldThrowException()
   {
      var livre = _fixture.Create<Livre>();
      var utilisateur = _fixture.Create<Utilisateur>();
      
      var command = new EmprunterLivreCommand(livre.Id, utilisateur.Id);
      
      _livreRepository.Setup(x => x.GetById(command.IdLivre))
         .ReturnsAsync((Livre?)null);
      
      await Assert.ThrowsAsync<EntityNotFoundException<Livre>>(() => _handler.Handle(command, CancellationToken.None));
   }

   [Fact(DisplayName = "Emprunter un livre avec utilisateur inexistant doit lever une exception")]
   public async Task EmprunterLivre_WithNonExistingUtilisateur_ShouldThrowException()
   {
      var livre = _fixture.Create<Livre>();
      
      var command = new EmprunterLivreCommand(livre.Id, Guid.NewGuid());
      
      _livreRepository.Setup(x => x.GetById(command.IdLivre))
         .ReturnsAsync(livre);
      
      _utilisateurRepository.Setup(x => x.GetById(command.IdUtilisateur))
         .ReturnsAsync((Utilisateur?)null);
      
      await Assert.ThrowsAsync<EntityNotFoundException<Utilisateur>>(() => _handler.Handle(command, CancellationToken.None));
   }

   /// <summary>
   /// Cette méthode est implémenté par l'interface IAsyncLifetime.
   /// Elle est appelé avant chaque début de test.
   /// Nous n'en avons pas d'utilité particulière ici, néanmoins, elle est nécessaire pour respecter l'interface.
   /// De plus, cela pourrait vous servir plus tard.
   /// </summary>
   /// <returns></returns>
   public Task InitializeAsync()
   {
      return Task.CompletedTask;
   }

   /// <summary>
   /// Cette méthode est implémenté par l'interface IAsyncLifetime.
   /// Elle est appelé à chaque fin de test.
   /// Cela nous permet de vérifier que nos mocks ont bien été utilisés et qu'il n'y a pas d'autres appels.
   /// </summary>
   /// <returns></returns>
   Task IAsyncLifetime.DisposeAsync()
   {
      _utilisateurRepository.VerifyAllAndNoOtherCalls();
      _livreRepository.VerifyAllAndNoOtherCalls();
      return Task.CompletedTask;
   }
}