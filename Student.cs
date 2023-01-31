using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentals
{
    public class Student
    {
        private int _studentId;
        public int StudentId { get { return _studentId; } }
        private void _setStudentId(int studentId)
        {
            if (studentId > 0)
            {
                _studentId = studentId;
            }
            else
            {
                throw new Exception("Student ID must be greater than zero");
            }
        }

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

        // Many students can each take one course
        public Enrolment? Enrolment { get; set; }

        private int? _courseGrade;
        public int? CourseGrade { get { return _courseGrade; } }
        public void SetCourseGrade(Enrolment e)
        {
            if (Enrolment == null)
            {
                throw new Exception("Student not enroled in course");
            }
            else if (e.CourseGrade < 0 || e.CourseGrade > 100)
            {
                throw new Exception("Grade must be between 0 and 100");
            }
            else
            {
                _courseGrade = e.CourseGrade;
            }
        }
        public void RemoveGrade()
        {
            _courseGrade = null;
        }

        private DateTime? _dateRegistered;
        public DateTime? DateRegistered
        {
            get { return _dateRegistered; }
            set { _dateRegistered = value; }
        }

        public Student(int studentId)
        {
            _setStudentId(studentId);
        }

        public Student(int studentId, string firstName, string lastName)
        {
            _setStudentId(studentId);

            // if we define public set methods on properties, we should
            // only use those to change the values of a field, so that
            // we use their validation
            FirstName = firstName;
            LastName = lastName;
            // if we use a field to change a value, we do not validate.
            // avoid direct assignment to a field (e.g _lastName = lasName)
        }
    }
}
