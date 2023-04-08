using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Repos;
using UMS.DTOS;
using University_Management_System;
using University_Management_System.Models;


namespace LogicLayer.Services
{
    public class StService 
    {    
        public static List<StudentDto> Get()
        {
            List<Student> students = StudentRepo.Get();
            List<StudentDto> studentDtos = new List<StudentDto>();

            foreach (var student in students)
            {
                StudentDto studentDto = new StudentDto
                {
                    StudentId = student.StudentId,
                    Name = student.Name,
                    Age = student.Age,
                    Dept = student.Dept,
                    Phone = student.Phone,
                    ImagePath = student.ImagePath
                };
                studentDtos.Add(studentDto);
            }

            return studentDtos;
        }

        public static StudentDto Get(int id)
        {
            Student student = StudentRepo.Get(id);
            if (student == null)
            {
                return null;
            }

            StudentDto studentDto = new StudentDto
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Age = student.Age,
                Dept = student.Dept,
                Phone = student.Phone,
                ImagePath = student.ImagePath
            };

            return studentDto;
        }

        public static bool Create(StudentDto studentDto)
        {
            Student student = new Student
            {
                Name = studentDto.Name,
                Age = studentDto.Age,
                Dept = studentDto.Dept,
                Phone = studentDto.Phone,
                ImagePath = studentDto.ImagePath
            };
            return StudentRepo.Create(student);
        }


        public static bool Update(StudentDto studentDto)
        {
            Student student = new Student
            {
                StudentId = studentDto.StudentId,
                Name = studentDto.Name,
                Age = studentDto.Age,
                Dept = studentDto.Dept,
                Phone = studentDto.Phone,
                ImagePath = studentDto.ImagePath
            };
            return StudentRepo.Update(student);
        }

        public static bool Delete(int id)
        {
            return StudentRepo.Delete(id);
        }
    }
}
