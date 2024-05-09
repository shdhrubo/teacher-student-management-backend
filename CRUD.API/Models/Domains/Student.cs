namespace CRUD.API.Models.Domains
{
  public class Student
  {
    public int Id { get; set; } 
    public  string Name { get; set; } 
    public  string Email { get; set; }
    //foreign key
    public  int TeacherId { get; set; }
    //navigation property
    public  Teacher Teacher { get; set; }
  }
}
