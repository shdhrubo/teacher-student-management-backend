using CRUD.API.Models.MongoModels;

namespace CRUD.API.Services
{
    public interface IOfficeStaffService
    {
        Task<IEnumerable<OfficeStaff>> GetAllOfficeStaffAsync();
        Task<OfficeStaff> GetOfficeStaffByIdAsync(string id);
        Task AddOfficeStaffAsync(OfficeStaff officeStaff);
        Task UpdateOfficeStaffAsync(string id, OfficeStaff officeStaff);
        Task DeleteOfficeStaffAsync(string id);
    }
}
