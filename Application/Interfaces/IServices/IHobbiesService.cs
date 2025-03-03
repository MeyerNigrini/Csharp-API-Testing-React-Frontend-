using Services.Models;


namespace Services.Interfaces.IServices
{
    public interface IHobbiesService
    {
        // Method to fetch and structure hobbies data
        Task<HobbiesModel> GetHobbiesAsync();
    }
}
