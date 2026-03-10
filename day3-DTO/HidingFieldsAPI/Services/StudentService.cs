using HidingFieldsAPI.Repository;
using HidingFieldsAPI.DTO;
using Microsoft.AspNetCore.Mvc;
        
using HidingFieldsAPI.Models;

namespace HidingFieldsAPI.Services
{
    public class StudentService
    {
        public readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _repo.GetAllAsync();
            return students.Select(students => new StudentDto() { FullName = "Welcome "+students.FullName, Email = students.Email, Status = students.Status }).ToList();
        }

        public async Task CreateNewStudent(StudentCreateDto student)  //3. Got the input from controller 
        {
            var newStudent = new Students() { FullName = student.FullName, Email = student.Email };  // 4. Mapping the inputs and creating a new object of student type.
            await _repo.AddAsync(newStudent);  //5. Sending the new object to Method in student repository
        }

    }
}
