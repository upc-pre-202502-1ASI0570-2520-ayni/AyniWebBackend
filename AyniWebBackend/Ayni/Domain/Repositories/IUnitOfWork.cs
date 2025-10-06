namespace AyniWebBackend.Ayni.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}