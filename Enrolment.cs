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

        private Student _student;
        public Student RegisteredStudent
        {
            get { return _student; }
            set { _student = value; }
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

        public Enrolment(int id, Student student, Course course, int? courseGrade, DateTime date)
        {
            Id = id;
            RegisteredStudent = student;
            Course = course;
            SetCourseGrade(courseGrade);
            DateRegistered = date;
        }
    }
}
