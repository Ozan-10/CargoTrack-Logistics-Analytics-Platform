using Dapper;
using DapperProjectDay.Context;
using DapperProjectDay.Dtos;

namespace DapperProjectDay.Repositories
{
    public class CustomerService : ICustomerService
    {
        private readonly DapperContext _context;

        public CustomerService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            string query = "insert into Customers (CustomerName,CustomerSurname,CustomerCity) values (@customerName,@customerSurname,@customerCity)";
            var parameters = new DynamicParameters();
            parameters.Add("@customerName", createCustomerDto.CustomerName);
            parameters.Add("@customerSurname", createCustomerDto.CustomerSurname);
            parameters.Add("@customerCity", createCustomerDto.CustomerCity);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            string query = "Delete From Customers Where CustomerId=@p";
            var parameters = new DynamicParameters();
            parameters.Add("@p", id);
            var connection = _context.CreateConnection();   
            await connection.ExecuteAsync(query, parameters);
        }

        public  async Task<List<ResultCustomerDto>> GetAllCustomerAsync()
        {
            string query = "Select * From Customers";
            var connection = _context.CreateConnection();
            var values= await connection.QueryAsync<ResultCustomerDto>(query);
            return values.ToList();
        }

        public async Task<GetCustomerByIdDto> GetCustomerByIdAsync(int id)
        {
            string query = "Select * From Customers Where CustomerId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstAsync<GetCustomerByIdDto>(query,parameters);
            return values;
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
        {
            string query = "update Customers Set CustomerName=@p1, CustomerSurname=@p2, CustomerCity=@p3 Where CustomerId=@p4";
            var parameters=new DynamicParameters();
            parameters.Add("@p1", updateCustomerDto.CustomerName);
            parameters.Add("@p2", updateCustomerDto.CustomerSurname);
            parameters.Add("@p3", updateCustomerDto.CustomerCity);
            parameters.Add("@p4", updateCustomerDto.CustomerId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
