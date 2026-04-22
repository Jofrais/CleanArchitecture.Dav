using CleanArchitecture.Dav.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Dav.Domain.Common.Repositories;

public interface IBaseRepository<T>
    where T : BaseEntity
{
    /// <summary>
    /// Récupère une entité par son identifiant unique
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T> GetById(Guid id);

    /// <summary>
    /// Récupère une liste d'entités
    /// </summary>
    /// <returns></returns>
    Task<List<T>> Get();
    
    /// <summary>
    /// Créer une entité.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<T> Create(T entity);

    /// <summary>
    /// Met à jour l'entité.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<T> Update(T entity);
}
