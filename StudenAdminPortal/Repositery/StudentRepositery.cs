using Microsoft.EntityFrameworkCore;
using StudenAdminPortal.Data;
using StudenAdminPortal.Models;

namespace StudenAdminPortal.Repositery
{
    public class StudentRepositery : IStudentRepositery
    {

        private readonly ApplicationDbContext _context; 
        
     public StudentRepositery(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync(); 

        }
        public async Task<List<Gender>> GetGendersAsync()
        {
            return await _context.Genders.ToListAsync(); 
        }
        public async Task<List<Student>> GetStudentsAsync(int Id)
        {
            return await _context.Students.Where(x => x.Id == Id).

                Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        } 
     public async Task<bool> Exists(int id)
        {
            return await _context.Genders.AnyAsync(x => x.Id == id); 
        } 
        public async Task<Student> UpdateStudent(int id, UpdateStudent student)
          //We are returning the Student That's why we are using the student Model  
        
            {
                var studentFromDb = await _context.Students.SingleOrDefaultAsync(x => x.Id == 22); 
                if(studentFromDb != null) // whatever the data coming from the front we have to check it   
                    {
                        studentFromDb.Name = student.Name;
                
                        studentFromDb.Email = student.Email;
                        studentFromDb.BirthDate = student.BirthDate;  
                    studentFromDb.GenderId = student.GenderId;
                
                    studentFromDb.Address.PhysicalAddress = student.PhysicalAddress;
                    studentFromDb.Address.PostalAddress = student.PostalAddress;
                    studentFromDb.Contact = student.Contact; 


                    await _context.SaveChangesAsync();
                    return studentFromDb; 

                }
                return null;  

            }

    }
}
