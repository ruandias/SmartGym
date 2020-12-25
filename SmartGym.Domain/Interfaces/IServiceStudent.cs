using System.Collections.Generic;
using SmartGym.Domain.Models;

namespace SmartGym.Domain.Interfaces
{
    public interface IServiceStudent
    {
        StudentModel Insert(CreateStudentModel userModel);

        StudentModel Update(int id, UpdateStudentModel studentModel);

        void Delete(int id);

        StudentModel RecoverById(int id);

        IEnumerable<StudentModel> RecoverAll();
    }
}
