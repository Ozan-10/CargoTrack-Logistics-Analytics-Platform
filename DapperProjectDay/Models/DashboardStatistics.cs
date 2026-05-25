namespace DapperProjectDay.Models
{
    public class DashboardStatistics
    {
        public int TotalShipments { get; set; }

        public int DeliveredOrders { get; set; }

        public int DelayedShipments { get; set; }

        public int ActiveBranches { get; set; }
        public List<int> MonthlyShipmentCounts { get; set; }

        public List<string> Months { get; set; }

        public int PreparingCount { get; set; }

        public int TransitCount { get; set; }
    }
}