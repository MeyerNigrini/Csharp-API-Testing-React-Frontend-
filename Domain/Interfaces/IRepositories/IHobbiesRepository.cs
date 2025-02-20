using Domain.Entities;


namespace Domain.Interfaces.IRepositories
{
    public interface IHobbiesRepository
    {
        Task<List<HobbiesEntity>> GetHobbiesWithDetailsAsync();
    }
}
