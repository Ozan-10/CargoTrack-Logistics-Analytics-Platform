using Dapper;
using DapperProjectDay.Context;
using DapperProjectDay.Dtos.ProductDtos;

namespace DapperProjectDay.Repositories
{
    public class ProductService : IProductService
    {
        private readonly DapperContext _context;
        private object? productId;

        public ProductService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            string query = "INSERT INTO Products (ProductName, Stock, Price, CategoryId) VALUES (@productName, @stock, @price, @categoryId)";
            var parameters = new DynamicParameters();
            parameters.Add("@productName", createProductDto.ProductName);
            parameters.Add("@stock", createProductDto.Stock);
            parameters.Add("@price", createProductDto.Price);
            parameters.Add("@categoryId", createProductDto.CategoryId);

            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

      
        public Task DeleteProductAsync(int id)
        {
            string query = "Delete From Products Where ProductId=@ıd";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            var connection = _context.CreateConnection();
            return connection.ExecuteAsync(query, parameters);
        }


        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            string query = "Select * From Products";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultProductDto>(query);
            return values.ToList();
        }

      
        public async Task<GetProductByIdDto> GetProductByIdAsync(int id)
        {
            string query = "Select * From Products Where ProductId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", productId);
            var connection = _context.CreateConnection();
           var values = await connection.QueryFirstAsync<GetProductByIdDto>(query,parameters);
            return values;
        }

      

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {

            string query = "Update Products Set ProductName=@produtname, Stock=@stock, Price=@price, CategoryId=@categoryId where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productName", updateProductDto.ProductName);
            parameters.Add("@stock", updateProductDto.Stock);
            parameters.Add("@price", updateProductDto.Price);
            parameters.Add("@categoryId", updateProductDto.CategoryId);
            parameters.Add("@productId", updateProductDto.ProductId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
