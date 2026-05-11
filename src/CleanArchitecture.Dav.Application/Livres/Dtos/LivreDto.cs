namespace CleanArchitecture.Dav.Application.Livres.Dtos;

public class LivreDto
{
    public required string Titre { get; set; }
    
    public required string Auteur { get; set; }
    
    public required string ISBN { get; set; }
    
    public EmpruntDto? Emprunt { get; set; }
    
    public List<EmpruntDto> HistoriqueEmprunts { get; set; } = new();
    
    public bool EstEmprunter => Emprunt != null;
}