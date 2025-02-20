using ApiTester.Domain.Entities;


namespace ApiTester.Domain.Interfaces.IRepositories
{
    public interface IHobbiesRepository
    {
        Task<List<HobbiesEntity>> GetHobbiesWithDetailsAsync();
    }
}
