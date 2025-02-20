using Application.Models;


namespace Application.Interfaces.IServices
{
    public interface IHobbiesService
    {
        // Method to fetch and structure hobbies data
        Task<HobbiesModel> GetHobbiesAsync();
    }
}
