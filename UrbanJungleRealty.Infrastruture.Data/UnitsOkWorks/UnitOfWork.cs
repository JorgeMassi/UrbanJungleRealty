﻿using UrbanJungleRealty.Application.Interfaces.UnitOfWork;
using UrbanJungleRealty.Infrastruture.Data.ApplicationDbContexts;

namespace UrbanJungleRealty.Infrastruture.Data.UnitsOkWorks;

public class UnitOfWork : IUnitOfWork
{
    private ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Commit()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public bool HasChanges()
    {
        return _context.ChangeTracker.HasChanges();
    }
}

