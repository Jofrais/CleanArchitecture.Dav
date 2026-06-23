using CleanArchitecture.Dav.Domain.Common.Entities;
using CleanArchitecture.Dav.Domain.Common.Repositories;
using CleanArchitecture.Dav.Infrastructure.DbsContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Dav.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T>
    where T : BaseEntity
{

    private readonly DbSet<T> _dbset;
    private readonly CleanArchitectureDbContext _cleanArchitectureDbContext;

    public BaseRepository(CleanArchitectureDbContext cleanArchitectureDbContext)
    {
        _dbset = cleanArchitectureDbContext.Set<T>();
        _cleanArchitectureDbContext = cleanArchitectureDbContext;
    }

    public async Task<T> Create(T entity)
    {
        _dbset.Add(entity);
        await _cleanArchitectureDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<T>> Get()
    {
        return await _dbset.ToListAsync();
    }

    public async Task<T?> GetById(Guid id)
    {
        return await _dbset.FindAsync(id);
    }

    public async Task<T> Update(T entity)
    {
        await _cleanArchitectureDbContext.SaveChangesAsync();
        return entity;
    }
}
