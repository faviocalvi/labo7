using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labo7.Models;
public class Database
{
    private List <Student> students;
    private static Database instance;
    private static readonly object _lock = new object();
    private Database()
    {
        students = new List<Student>();
    }
    public static Database Instance
    {
        get
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }
    }

    public void addStudent(Student student)
    {
        students.Add(student);
    }
    public List<Student> searchStudentByName(string searcTerm)
    {
        return students.Where(student => student.Name.Contains(searcTerm, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Student> searchStudentByLastname(string searchTerm)
    {
        return students.Where(student => student.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    public List<Student> searchStudentByEmail(string searchTerm)
    {
        return students.Where(student => student.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    public List<Student> GetStudents()
    {
        return students;
    }

}
