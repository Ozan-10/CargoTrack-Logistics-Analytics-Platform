using DapperProjectDay.Dtos;

namespace DapperProjectDay.Repositories
{
    public interface ICustomerService
    {
        Task<List<ResultCustomerDto>> GetAllCustomerAsync();
        Task CreateCustomerAsync(CreateCustomerDto createCustomerDto);
        Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto);
        Task DeleteCustomerAsync(int Id);
        Task<GetCustomerByIdDto> GetCustomerByIdAsync(int id);
    }
}
