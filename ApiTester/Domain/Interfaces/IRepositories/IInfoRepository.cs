using ApiTester.Domain.Models;

namespace ApiTester.Domain.Interfaces.IRepositories
{
    // IInfoRepository defines the data access contract for Info data
    public interface IInfoRepository
    {
        Task<List<InfoEntity>> GetInfoDataAsync();
    }
}
