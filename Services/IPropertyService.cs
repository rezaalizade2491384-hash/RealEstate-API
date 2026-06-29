using RealEstate.Api.DTOs;

namespace RealEstate.Api.Services
{
    public interface IPropertyService
    {
        Task<IEnumerable<PropertyDto>> GetAllAsync();
        Task<PropertyDto?> GetByIdAsync(int id);
        Task<PropertyDto> CreateAsync(CreatePropertyDto createDto);
        Task<PropertyDto?> UpdateAsync(int id, UpdatePropertyDto updateDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}