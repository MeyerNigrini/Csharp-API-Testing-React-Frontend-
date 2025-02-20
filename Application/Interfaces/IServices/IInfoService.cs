using Application.Models;

namespace Application.Interfaces.IServices
{
    public interface IInfoService
    {
        Task<InfoModel> GetInfoDataAsync(); // Fetch and return structured Info data
    }
}
