﻿using ApiTester.Domain.Entities;

namespace ApiTester.Domain.Interfaces.IRepositories
{
    // IInfoRepository defines the data access contract for Info data
    public interface IInfoRepository
    {
        Task<List<InfoEntity>> GetInfoDataAsync();
    }
}
