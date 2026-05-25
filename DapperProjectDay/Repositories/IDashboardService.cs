using DapperProjectDay.Models;

namespace DapperProjectDay.Repositories
{
    public interface IDashboardService
    {
        Task<DashboardStatistics> GetStatisticsAsync();
    }
}