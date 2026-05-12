using AutoFixture;
using CleanArchitecture.Dav.Application.Livres.UseCases.Commands.Retourner;
using CleanArchitecture.Dav.Application.Tests.Common.Extensions;
using CleanArchitecture.Dav.Domain.Common.Exceptions;
using CleanArchitecture.Dav.Domain.Livres.Entities;
using CleanArchitecture.Dav.Domain.Livres.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace CleanArchitecture.Dav.Application.Tests.Livres.UsesCases.Commands;

public class RetournerLivreHandlerTests : IAsyncLifetime
{
    private readonly Mock<ILivreRepository> _livreRepositoryMock;
    private readonly Fixture _fixture = new();
    private readonly RetournerLivreHandler _handler;

    public RetournerLivreHandlerTests()
    {
        _livreRepositoryMock = new Mock<ILivreRepository>();
        _handler = new RetournerLivreHandler(Mock.Of<ILogger<RetournerLivreHandler>>(),
            _livreRepositoryMock.Object);
    }

    [Fact(DisplayName = "Retourner un livre doit retourner un LivreDto")]
    private async Task RetournerLivre_ShouldReturnLivreDto()
    {
        var livre = _fixture.Build<Livre>()
            .With(x => x.Emprunt, _fixture.Create<Emprunt>())
            .Without(x => x.HistoriqueEmprunts)
            .Create();
        
        _livreRepositoryMock.Setup(x => x.GetById(livre.Id))
            .ReturnsAsync(livre);
        
        _livreRepositoryMock.Setup(x => x.Update(It.Is<Livre>(livre => livre.Id == livre.Id)))
            .ReturnsAsync((Livre livreEnParametre) => livreEnParametre);
        
        var livreDto = await _handler.Handle(new RetournerLivreCommand(livre.Id), CancellationToken.None);
        
        Assert.NotNull(livreDto);
        Assert.Equal(livre.Id, livreDto.Id);
        
        Assert.Null(livreDto.Emprunt);
        Assert.Single(livreDto.HistoriqueEmprunts);
        Assert.True(livreDto.HistoriqueEmprunts.First().DateRetour.HasValue);
    }
    
    [Fact(DisplayName = "Retourner un livre avec livre inexistant doit lever une exception")]
    private async Task RetournerLivre_ShouldThrowExceptionWhenLivreNotFound()
    {
        _livreRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
            .ReturnsAsync((Livre?)null);
        
        await Assert.ThrowsAsync<EntityNotFoundException<Livre>>(() => _handler.Handle(new RetournerLivreCommand(Guid.NewGuid()), CancellationToken.None));
    }
    
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        _livreRepositoryMock.VerifyAllAndNoOtherCalls();
        return Task.CompletedTask;
    }
}