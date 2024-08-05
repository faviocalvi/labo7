using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labo7.Models;
public class Student
{
    private string name;
    private string lastName;
    private string email;

    public Student(string name, string lastName, string email)
    {
        this.name = name;
        this.lastName = lastName;
        this.email = email;

    }
       
    public string Name
    {

        get { return name; }
        set { name = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    public string Email
    {
        get { return email; }
        set { email = value; }
    }

}
