using SmartGym.Domain.Entities;
using SmartGym.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartGym.Infra.Shared.Mapper
{
    public static class StudentMapper
    {
        public static Student ConvertToStudentEntity(this CreateStudentModel studentModel) =>
            new Student(studentModel.Name, studentModel.Address);

        public static Student ConvertToStudentEntity(this UpdateStudentModel studentModel) =>
            new Student(studentModel.Name , studentModel.Address);

        public static IEnumerable<StudentModel> ConvertToStudents(this IList<Student> students) =>
            new List<StudentModel>(students.Select(s => new StudentModel(s.Id, s.Name.ToString(), s.Address)));

        public static StudentModel ConvertToStudent(this Student student) =>
            new StudentModel(student.Id, student.Name.ToString(), student.Address);
    }
}
