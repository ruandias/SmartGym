using SmartGym.Domain.Entities;
using SmartGym.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Shared.Mapper
{
    public static class StudentMapper
    {
        public static Student ConvertToStudentEntity(this CreateStudentModel studentModel) =>
             new Student(0, studentModel.PersonalTrainerId, studentModel.PersonalTrainerId, studentModel.Name);

        public static Student ConvertToStudentEntity(this UpdateStudentModel studentModel) =>
            new Student(studentModel.Id, studentModel.PersonalTrainerId, studentModel.TrainingCenterId, studentModel.Name);

        public static IEnumerable<StudentModel> ConvertToStudents(this IList<Student> students) =>
            new List<StudentModel>(students.Select(s => new StudentModel(s.Id, s.Name.ToString())));

        public static StudentModel ConvertToStudent(this Student student) =>
            new StudentModel(student.Id, student.Name.ToString());
    }
}
