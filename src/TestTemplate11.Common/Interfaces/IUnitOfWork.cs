using System.Threading.Tasks;

namespace TestTemplate11.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
    }
}