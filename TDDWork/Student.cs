using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDWork
{
    public class Student
    {
        public string Id;
        public string firstName;
        public string surName;
        public string email;
        public string phoneNumber;
        public double GPA;
        private double[] grades;
        public Student(string Id,string firstName,string surName,string email,string phoneNumber, double[] grades)
        {
            this.Id = Id;
            this.email = email;
            this.firstName = firstName;
            this.surName = surName;
            this.grades = grades;
            this.phoneNumber = phoneNumber;
            this.GPA = Math.Round(get_GPA(), 2);
        }
        public string get_Id()
        {
            return this.Id;
        }
        public string get_firstName()
        {
            return this.firstName;
        }
        public string get_surName()
        {
            return this.surName;
        }
        public string get_email()
        {
            return this.email;
        }
        public string get_phoneNumber()
        {
            return this.phoneNumber;
        }
        public double get_GPA()
        {
            double average = 0;
            foreach(double grade in this.grades)
                average += grade == 777 ? 0 : grade;
            return average/5.0;
        }
        public static Boolean operator >=(Student a,Student b)
        {
            return a.get_GPA()>=b.get_GPA();
        }
        public static Boolean operator <=(Student a, Student b)
        {
            return a.get_GPA() <= b.get_GPA();
        }
        public static Boolean operator >(Student a, Student b)
        {
            return !(a <= b);
        }
        public static Boolean operator <(Student a, Student b)
        {
            return !(a >= b);
        }
    }
}
