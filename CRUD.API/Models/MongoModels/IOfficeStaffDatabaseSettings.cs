namespace CRUD.API.Models.MongoModels
{
    public interface IOfficeStaffDatabaseSettings
    {
        string TeacherStudentCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
