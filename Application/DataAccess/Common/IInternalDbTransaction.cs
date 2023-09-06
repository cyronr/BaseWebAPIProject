namespace Application.DataAccess.Common
{
    public interface IInternalDbTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}