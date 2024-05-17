namespace CRUD.API.Models.MongoModels
{
    public class OfficeStaffDatabaseSettings : IOfficeStaffDatabaseSettings
    {
        public string TeacherStudentCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
