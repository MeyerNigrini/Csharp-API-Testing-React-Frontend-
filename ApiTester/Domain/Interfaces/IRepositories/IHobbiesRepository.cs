using ApiTester.Domain.Models;


namespace ApiTester.Domain.Interfaces.IRepositories
{
    public interface IHobbiesRepository
    {
        Task<List<HobbiesModel>> GetHobbiesWithDetailsAsync();
    }
}
