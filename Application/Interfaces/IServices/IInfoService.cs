using Services.Models;

namespace Services.Interfaces.IServices
{
    public interface IInfoService
    {
        Task<InfoModel> GetInfoDataAsync(); // Fetch and return structured Info data
    }
}
