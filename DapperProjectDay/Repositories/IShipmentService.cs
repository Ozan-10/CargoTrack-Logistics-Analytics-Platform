using DapperProjectDay.Models;

namespace DapperProjectDay.Repositories
{
    public interface IShipmentService
    {
        Task<List<Shipment>> GetAllShipmentsAsync();
        Task<List<Shipment>> GetPagedShipmentsAsync(int page, int pageSize);
            Task<List<Shipment>> GetFilteredShipmentsAsync(
                string trackingCode,
                string senderCity,
                string status,
                int page,
                int pageSize);

        Task CreateShipmentAsync(Shipment shipment);

        Task DeleteShipmentAsync(int id);

        Task<Shipment> GetShipmentByIdAsync(int id);

        Task UpdateShipmentAsync(Shipment shipment);
    }
}