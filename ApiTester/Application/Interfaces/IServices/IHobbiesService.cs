using ApiTester.Application.Models;


namespace ApiTester.Application.Interfaces.IServices
{
    public interface IHobbiesService
    {
        // Method to fetch and structure hobbies data
        Task<HobbiesModel> GetHobbiesAsync();
    }
}
