using StudenAdminPortal.Models;

namespace StudenAdminPortal.Repositery
{
    public interface IStudentRepositery
    {
        
      Task<List<Student>> GetAllStudentsAsync(); 
      Task<List<Student>> GetStudentsAsync(int id); 
      Task<List<Gender>> GetGendersAsync(); 
      Task<bool> Exists(int id);  
      Task<Student> UpdateStudent(int id, UpdateStudent student); 

    }
} 



 


