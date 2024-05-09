namespace CRUD.API.Models.DTOs
{
  public class StudentDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int TeacherId { get; set; }
  }
}
