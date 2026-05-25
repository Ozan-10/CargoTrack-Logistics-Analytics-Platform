using Dapper;
using DapperProjectDay.Context;
using DapperProjectDay.Models;
using DapperProjectDay.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperProjectDay.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly IShipmentService _shipmentService;
        private readonly DapperContext _context;

        public ShipmentController(
            IShipmentService shipmentService,
            DapperContext context)
        {
            _shipmentService = shipmentService;
            _context = context;
        }

        public async Task<IActionResult> Index(
            string trackingCode,
            string senderCity,
            string status,
            int page = 1)
        {
            int pageSize = 12;

            var values = await _shipmentService
                .GetFilteredShipmentsAsync(
                    trackingCode,
                    senderCity,
                    status,
                    page,
                    pageSize);

            return View(values);
        }

        [HttpGet]
        public IActionResult CreateShipment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateShipment(Shipment shipment)
        {
            shipment.ShipmentDate = DateTime.Now;

            await _shipmentService.CreateShipmentAsync(shipment);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteShipment(int id)
        {
            await _shipmentService.DeleteShipmentAsync(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditShipment(int id)
        {
            var values = await _shipmentService
                .GetShipmentByIdAsync(id);

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> EditShipment(Shipment shipment)
        {
            await _shipmentService.UpdateShipmentAsync(shipment);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            var connection = _context.CreateConnection();

            string query = "SELECT * FROM Shipments WHERE ShipmentId=@id";

            var values = await connection
                .QueryFirstOrDefaultAsync<ShipmentDetailViewModel>(
                    query,
                    new { id });

            return View(values);
        }
    }
}