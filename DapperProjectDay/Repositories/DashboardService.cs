using Dapper;
using DapperProjectDay.Context;
using DapperProjectDay.Models;

namespace DapperProjectDay.Repositories
{
    public class DashboardService : IDashboardService
    {
        private readonly DapperContext _context;

        public DashboardService(DapperContext context)
        {
            _context = context;
        }

        public async Task<DashboardStatistics> GetStatisticsAsync()
        {
            string query = @"

            SELECT
            (SELECT COUNT(*) FROM Shipments) AS TotalShipments,

            (SELECT COUNT(*) 
             FROM Shipments
             WHERE Status='Delivered') AS DeliveredOrders,

            (SELECT COUNT(*) 
             FROM Shipments
             WHERE Status='Delayed') AS DelayedShipments,

            (SELECT COUNT(*) FROM Branches) AS ActiveBranches
            ";

            var connection = _context.CreateConnection();

            var values = await connection
     .QueryFirstOrDefaultAsync<DashboardStatistics>(query);
            var monthlyData = await connection.QueryAsync<dynamic>(@"

SELECT
DATENAME(MONTH, ShipmentDate) AS MonthName,
COUNT(*) AS ShipmentCount

FROM Shipments

GROUP BY DATENAME(MONTH, ShipmentDate),
MONTH(ShipmentDate)

ORDER BY MONTH(ShipmentDate)

");

            values.Months = monthlyData
                .Select(x => (string)x.MonthName)
                .ToList();

            values.MonthlyShipmentCounts = monthlyData
                .Select(x => (int)x.ShipmentCount)
                .ToList();
            values.PreparingCount = await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(*) FROM Shipments WHERE Status='Preparing'");

            values.TransitCount = await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(*) FROM Shipments WHERE Status='In Transit'");

            return values;
        }
    }
}