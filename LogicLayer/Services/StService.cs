using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer;
using DataLayer.Repos;
using LogicLayer.DTOS;
using UMS.DTOS;
using University_Management_System;
using University_Management_System.Models;


namespace LogicLayer.Services
{
    public class StService 
    {    
        public static List<StudentDto> Get()
        {          
            var data = DataAccessFactory.StudentDataAccess().Read();
            var config = new MapperConfiguration(c => { c.CreateMap<Student,StudentDto>(); });  

            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<StudentDto>>(data);
            return mapped;
        }

        public static StudentDto Get(int id)
        {
            var data = DataAccessFactory.StudentDataAccess().Read(id);
            var config = new MapperConfiguration(c => { c.CreateMap<Student, StudentDto>(); });

            var mapper = new Mapper(config);
            return mapper.Map<StudentDto>(data);
        }

        public static StudentDto Create(StudentDto studentDto)
        {  
            var config = new MapperConfiguration(c => { c.CreateMap<Student, StudentDto>(); });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<Student>(studentDto);
            var data = DataAccessFactory.StudentDataAccess().Create(mapped);
            if (data != null)
            {
                return mapper.Map<StudentDto>(data);
            }
            return null;
        }


        public static StudentDto Update(StudentDto studentDto)
        {
            var config = new MapperConfiguration(c => { c.CreateMap<Student, StudentDto>(); });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<Student>(studentDto);
            var data = DataAccessFactory.StudentDataAccess().Update(mapped);
            if (data != null)
            {
                return mapper.Map<StudentDto>(data);
            }
            return null;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.StudentDataAccess().Delete(id);
            return data;
        }
    }
}
