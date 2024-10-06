namespace UrbanJungleRealty.Application.Interfaces.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    Task<bool> Commit();
    bool HasChanges();
}
