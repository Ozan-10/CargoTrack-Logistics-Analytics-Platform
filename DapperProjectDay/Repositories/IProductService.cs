using DapperProjectDay.Dtos.ProductDtos;

namespace DapperProjectDay.Repositories
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
        Task<GetProductByIdDto> GetProductByIdAsync(int id);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(int id);
    }
}