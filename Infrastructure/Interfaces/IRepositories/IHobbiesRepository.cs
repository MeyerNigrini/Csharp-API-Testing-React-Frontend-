using Infrastructure.Entities;


namespace Infrastructure.Interfaces.IRepositories
{
    public interface IHobbiesRepository
    {
        Task<List<HobbiesEntity>> GetHobbiesWithDetailsAsync();
    }
}
