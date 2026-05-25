using Dapper;
using DapperProjectDay.Context;
using DapperProjectDay.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperProjectDay.Controllers
{
    public class CourierController : Controller
    {
        private readonly DapperContext _context;

        public CourierController(DapperContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var connection = _context.CreateConnection();

            string query = "SELECT * FROM Couriers";

            var values = await connection.QueryAsync<Courier>(query);

            return View(values);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var connection = _context.CreateConnection();

            string query = "SELECT * FROM Couriers WHERE CourierId=@id";

            var values = await connection.QueryFirstOrDefaultAsync<Courier>(query, new
            {
                id
            });

            return View(values);
        }
    }
}