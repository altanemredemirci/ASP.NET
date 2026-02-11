using _12_Dependency_Injection.Models;
using System.Linq.Expressions;

namespace _12_Dependency_Injection.Services
{
    public interface IStudentService
    {
        int Create(Student student);
        int Update();
        int Delete(int id);
        List<Student> GetStudents();
        Student Find(int id);
        List<Student> List(Expression<Func<Student, bool>> filter);
    }
}
