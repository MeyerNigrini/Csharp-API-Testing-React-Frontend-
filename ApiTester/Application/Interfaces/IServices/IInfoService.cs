using ApiTester.Application.Models;

namespace ApiTester.Application.Interfaces.IServices
{
    public interface IInfoService
    {
        Task<InfoModel> GetInfoDataAsync(); // Fetch and return structured Info data
    }
}
