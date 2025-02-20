using ApiTester.Application.DTOs;

namespace ApiTester.Domain.Interfaces.IServices
{
    public interface IInfoService
    {
        Task<InfoModel> GetInfoDataAsync(); // Fetch and return structured Info data
    }
}
