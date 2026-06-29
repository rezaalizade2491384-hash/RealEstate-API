using AutoMapper;
using RealEstate.Api.Data.Entities;
using RealEstate.Api.DTOs;
using RealEstate.Api.Repositories;

namespace RealEstate.Api.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repository;
        private readonly IMapper _mapper;

        public PropertyService(IPropertyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropertyDto>> GetAllAsync()
        {
            var properties = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PropertyDto>>(properties);
        }

        public async Task<PropertyDto?> GetByIdAsync(int id)
        {
            var property = await _repository.GetByIdAsync(id);
            if (property == null)
                return null;

            return _mapper.Map<PropertyDto>(property);
        }

        public async Task<PropertyDto> CreateAsync(CreatePropertyDto createDto)
        {
            var property = _mapper.Map<Property>(createDto);
            property.CreatedAt = DateTime.Now;

            await _repository.AddAsync(property);
            await _repository.SaveChangesAsync();

            return _mapper.Map<PropertyDto>(property);
        }

        public async Task<PropertyDto?> UpdateAsync(int id, UpdatePropertyDto updateDto)
        {
            var property = await _repository.GetByIdAsync(id);
            if (property == null)
                return null;

            _mapper.Map(updateDto, property);
            await _repository.SaveChangesAsync();

            return _mapper.Map<PropertyDto>(property);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exists = await _repository.ExistsAsync(id);
            if (!exists)
                return false;

            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }
    }
}