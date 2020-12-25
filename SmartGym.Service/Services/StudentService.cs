using Flunt.Validations;
using SmartGym.Domain.Interfaces;
using SmartGym.Domain.Models;
using SmartGym.Infra.Shared.Contexts;
using SmartGym.Infra.Shared.Mapper;
using System.Collections.Generic;

namespace SmartGym.Service.Services
{
    public class StudentService : IServiceStudent
    {
        private readonly IRepositoryStudent _repositoryStudent;
        private readonly NotificationContext _notificationContext;

        public StudentService(IRepositoryStudent repositoryStudent, NotificationContext notificationContext)
        {
            _repositoryStudent = repositoryStudent;
            _notificationContext = notificationContext;
        }

        public IEnumerable<StudentModel> RecoverAll()
        {
            var students = _repositoryStudent.GetAll();
            return students.ConvertToStudents();
        }

        public StudentModel RecoverById(int id)
        {
            var student = _repositoryStudent.GetById(id);
            return student.ConvertToStudent();
        }

        public void Delete(int id) =>
            _repositoryStudent.Remove(id);

        public StudentModel Insert(CreateStudentModel studentModel)
        {
            var student = studentModel.ConvertToStudentEntity();
            _notificationContext.AddNotifications(student.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositoryStudent.Save(student);
            return student.ConvertToStudent();
        }


        public StudentModel Update(int id, UpdateStudentModel studentModel)
        {
            if (id != studentModel.Id)
            {
                _notificationContext.AddNotifications(new Contract().AreNotEquals(id, studentModel.Id, nameof(id), "Student not found."));

                return default;
            }

            var student = studentModel.ConvertToStudentEntity();
            _notificationContext.AddNotifications(student.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositoryStudent.Save(student);
            return student.ConvertToStudent();
        }
    }

}
