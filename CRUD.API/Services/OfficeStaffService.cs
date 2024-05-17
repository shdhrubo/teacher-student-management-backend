using CRUD.API.Models.MongoModels;
using CRUD.API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.API.Services
{
    public class OfficeStaffService : IOfficeStaffService
    {
        private readonly IMongoGenericRepository<OfficeStaff> _officeStaffRepository;

        public OfficeStaffService(IMongoGenericRepository<OfficeStaff> officeStaffRepository)
        {
            _officeStaffRepository = officeStaffRepository ?? throw new ArgumentNullException(nameof(officeStaffRepository));
        }

        public async Task<IEnumerable<OfficeStaff>> GetAllOfficeStaffAsync()
        {
            return await _officeStaffRepository.GetAllAsync();
        }

        public async Task<OfficeStaff> GetOfficeStaffByIdAsync(string id)
        {
            return await _officeStaffRepository.GetByIdAsync(id);
        }

        public async Task AddOfficeStaffAsync(OfficeStaff officeStaff)
        {
            await _officeStaffRepository.AddAsync(officeStaff);
        }

        public async Task UpdateOfficeStaffAsync(string id, OfficeStaff officeStaff)
        {
            var existingOfficeStaff = await GetOfficeStaffByIdAsync(id);
            if (existingOfficeStaff == null)
            {
                throw new InvalidOperationException($"Office staff with ID {id} not found.");
            }

            officeStaff.Id = existingOfficeStaff.Id;
            await _officeStaffRepository.UpdateAsync(id, officeStaff);
        }

        public async Task DeleteOfficeStaffAsync(string id)
        {
            var existingOfficeStaff = await GetOfficeStaffByIdAsync(id);
            if (existingOfficeStaff == null)
            {
                throw new InvalidOperationException($"Office staff with ID {id} not found.");
            }

            await _officeStaffRepository.DeleteAsync(id);
        }
    }
}
