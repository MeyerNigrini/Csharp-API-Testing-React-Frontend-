using ApiTester.Application.DTOs;


namespace ApiTester.Domain.Interfaces.IServices
{
    public interface IHobbiesService
    {
        // Method to fetch and structure hobbies data
        Task<HobbiesModel> GetHobbiesAsync();
    }
}
