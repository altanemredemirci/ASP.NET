using _12_Dependency_Injection.DataContext;
using _12_Dependency_Injection.Models;
using System.Linq.Expressions;

namespace _12_Dependency_Injection.Services
{
    public class StudentService : IStudentService
    {
        public int Create(Student student)
        {
            using(ProjectContext db = new ProjectContext())
            {
                db.Students.Add(student);
                return db.SaveChanges();
            }
        }

        public int Delete(int id)
        {
            using(ProjectContext db = new ProjectContext())
            {
                //Find metodu sadece primary key olan kolon bilgisi ile çalışır. Genellikle Id kolonu(property) int ve primary keydir.
                var student = db.Students.Find(id);
                if(student != null)
                {
                    db.Students.Remove(student);
                    return db.SaveChanges();
                }

                return 0;
            }
        }

        public Student Find(int id)
        {
            using (ProjectContext db = new ProjectContext())
            {              
                var student = db.Students.Find(id);
                if (student != null)
                {
                    return student;
                }
                return null;
            }
        }

        public List<Student> GetStudents()
        {
            using(ProjectContext db = new ProjectContext())
            {
                var students = db.Students.ToList();
                return students;
            }
        }

        public List<Student> List(Expression<Func<Student, bool>> filter)
        {
            using (ProjectContext db = new ProjectContext())
            {
                var students = db.Students.Where(filter).ToList();
                return students;
            }

        }

        public int Update()
        {
            using(ProjectContext db = new ProjectContext())
            {
                return db.SaveChanges();
            }
        }
    }
}
