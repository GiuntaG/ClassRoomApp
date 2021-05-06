using System.Collections.Generic;

namespace Exercises.Services
{
    public interface ISimplifyFractionService
    {
        bool AddStudent(Student student);

        IEnumerable<Student> GetAllStudents();

        string ReduceFraction (int nbrNumerator, int nbrDenominator);
    }
}