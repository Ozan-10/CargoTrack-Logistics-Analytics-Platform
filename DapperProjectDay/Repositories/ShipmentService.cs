using Dapper;
using DapperProjectDay.Context;
using DapperProjectDay.Models;

namespace DapperProjectDay.Repositories
{
    public class ShipmentService : IShipmentService
    {
        private readonly DapperContext _context;

        public ShipmentService(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<Shipment>> GetAllShipmentsAsync()
        {
            string query = "Select * From Shipments";

            var connection = _context.CreateConnection();

            var values = await connection.QueryAsync<Shipment>(query);

            return values.ToList();
        }
        public async Task<List<Shipment>> GetPagedShipmentsAsync(int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;

            string query = @$"
    SELECT *
    FROM Shipments
    ORDER BY ShipmentId
    OFFSET @Skip ROWS
    FETCH NEXT @PageSize ROWS ONLY";

            var connection = _context.CreateConnection();

            var values = await connection.QueryAsync<Shipment>(
                query,
                new
                {
                    Skip = skip,
                    PageSize = pageSize
                });

            return values.ToList();
        }
        public async Task<List<Shipment>> GetFilteredShipmentsAsync(
    string trackingCode,
    string senderCity,
    string status,
    int page,
    int pageSize)
        {
            int skip = (page - 1) * pageSize;

            string query = @"
    SELECT *
    FROM Shipments
    WHERE
    (@TrackingCode IS NULL OR TrackingCode LIKE '%' + @TrackingCode + '%')
    AND
    (@SenderCity IS NULL OR SenderCity LIKE '%' + @SenderCity + '%')
    AND
    (@Status IS NULL OR Status = @Status)

    ORDER BY ShipmentId

    OFFSET @Skip ROWS
    FETCH NEXT @PageSize ROWS ONLY";

            var connection = _context.CreateConnection();

            var values = await connection.QueryAsync<Shipment>(
                query,
                new
                {
                    TrackingCode = trackingCode,
                    SenderCity = senderCity,
                    Status = status,
                    Skip = skip,
                    PageSize = pageSize
                });

            return values.ToList();
        }
        public async Task CreateShipmentAsync(Shipment shipment)
        {
            string query = @"
    INSERT INTO Shipments
    (TrackingCode,
    SenderCity,
    ReceiverCity,
    BranchId,
    CourierId,
    Status,
    Weight,
    ShippingPrice,
    ShipmentDate,
    DeliveryDate)

    VALUES

    (@TrackingCode,
    @SenderCity,
    @ReceiverCity,
    @BranchId,
    @CourierId,
    @Status,
    @Weight,
    @ShippingPrice,
    @ShipmentDate,
    @DeliveryDate)";

            var connection = _context.CreateConnection();

            await connection.ExecuteAsync(query, shipment);
        }
        public async Task DeleteShipmentAsync(int id)
        {
            string query = "DELETE FROM Shipments WHERE ShipmentId=@id";

            var connection = _context.CreateConnection();

            await connection.ExecuteAsync(query, new { id });
        }

        public async Task<Shipment> GetShipmentByIdAsync(int id)
        {
            string query = "SELECT * FROM Shipments WHERE ShipmentId=@id";

            var connection = _context.CreateConnection();

            var values = await connection
                .QueryFirstOrDefaultAsync<Shipment>(query, new { id });

            return values;
        }

        public async Task UpdateShipmentAsync(Shipment shipment)
        {
            string query = @"

    UPDATE Shipments
    SET

    TrackingCode=@TrackingCode,
    SenderCity=@SenderCity,
    ReceiverCity=@ReceiverCity,
    Status=@Status,
    Weight=@Weight,
    ShippingPrice=@ShippingPrice

    WHERE ShipmentId=@ShipmentId";

            var connection = _context.CreateConnection();

            await connection.ExecuteAsync(query, shipment);
        }
    }
}