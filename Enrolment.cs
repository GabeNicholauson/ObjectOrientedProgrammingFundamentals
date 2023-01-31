using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentals
{
    public class Enrolment
    {
        private int _id;
        public int Id 
        { 
            get { return _id; } 
            set { _id = value; }
                }

        public Course Course { get; set; }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value.Length > 0)
                {
                    _firstName = value;
                }
                else
                {
                    throw new Exception("Cannot be empty.");
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value.Length > 0)
                {
                    _lastName = value;
                }
                else
                {
                    throw new Exception("Cannot be empty.");
                }
            }
        }

        private int? _courseGrade;
        public int? CourseGrade { get { return _courseGrade; } }
        public void SetCourseGrade(int? grade)
        {
            if (Course == null)
            {
                throw new Exception("Student not enroled in course");
            }
            else if (grade < 0 || grade > 100)
            {
                throw new Exception("Grade must be between 0 and 100");
            }
            else
            {
                _courseGrade = grade;
            }
        }

        private DateTime _dateRegistered;
        public DateTime DateRegistered
        {
            get { return _dateRegistered; }
            set { _dateRegistered = value; }
        }

        public Enrolment(int id, string firstName, string lastName, Course course, int? courseGrade, DateTime date)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Course = course;
            SetCourseGrade(courseGrade);
            DateRegistered = date;
        }
    }
}
