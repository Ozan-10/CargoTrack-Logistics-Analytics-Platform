using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperProjectDay.Controllers
{
    public class ImportController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(200_000_000)]
        public async Task<IActionResult> Index(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return Content("Dosya seçilmedi");
            }

            DataTable table = new DataTable();

            table.Columns.Add("TrackingCode");
            table.Columns.Add("SenderCity");
            table.Columns.Add("ReceiverCity");
            table.Columns.Add("BranchId");
            table.Columns.Add("CourierId");
            table.Columns.Add("Status");
            table.Columns.Add("Weight");
            table.Columns.Add("ShippingPrice");
            table.Columns.Add("ShipmentDate");
            table.Columns.Add("DeliveryDate");

            using var reader = new StreamReader(file.OpenReadStream());

            bool isFirstLine = true;

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();

                if (isFirstLine)
                {
                    isFirstLine = false;
                    continue;
                }

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var values = line.Split(',');

                if (values.Length != 10)
                    continue;

                table.Rows.Add(
                    values[0],
                    values[1],
                    values[2],
                    values[3],
                    values[4],
                    values[5],
                    values[6],
                    values[7],
                    values[8],
                    values[9]
                );
            }

            using SqlConnection connection =
                new SqlConnection(
                    "Server=(local)\\SQLEXPRESS;Database=CargoTrackDb;Integrated Security=True;TrustServerCertificate=True");

            await connection.OpenAsync();

            using SqlBulkCopy bulkCopy = new SqlBulkCopy(connection);

            bulkCopy.DestinationTableName = "Shipments";

            bulkCopy.ColumnMappings.Add("TrackingCode", "TrackingCode");
            bulkCopy.ColumnMappings.Add("SenderCity", "SenderCity");
            bulkCopy.ColumnMappings.Add("ReceiverCity", "ReceiverCity");
            bulkCopy.ColumnMappings.Add("BranchId", "BranchId");
            bulkCopy.ColumnMappings.Add("CourierId", "CourierId");
            bulkCopy.ColumnMappings.Add("Status", "Status");
            bulkCopy.ColumnMappings.Add("Weight", "Weight");
            bulkCopy.ColumnMappings.Add("ShippingPrice", "ShippingPrice");
            bulkCopy.ColumnMappings.Add("ShipmentDate", "ShipmentDate");
            bulkCopy.ColumnMappings.Add("DeliveryDate", "DeliveryDate");

            await bulkCopy.WriteToServerAsync(table);

            return Content($"Başarılı! {table.Rows.Count} kayıt aktarıldı.");
        }
    }
}