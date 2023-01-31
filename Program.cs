using System;
using ObjectOrientedProgrammingFundamentals;

Course Software = new Course(200, "Software Developer", 30);
Student Jimmy = new Student(1000, "Jimmy", "Smith");
// a course can have many students in it, and a 
// student can take one course
// one-to-many relationship (one course, many students)

// "one" component needs a collection of many (course needs a 
// collection of students)
// "many" component needs a propertyfor the "one" (student needs a property of course)
try
{
    registerStudent(Jimmy, Software);
    Console.WriteLine(Jimmy.Course.Title);
    Console.WriteLine(Jimmy.DateRegistered);
    deregisterStudent(Jimmy, Software);
    Console.WriteLine(Jimmy.DateRegistered);
    Console.WriteLine(Software.GetStudentInCourse(Jimmy.StudentId));
    Console.WriteLine(Jimmy.Course);
    deregisterStudent(Jimmy, Software);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
void registerStudent(Student student, Course course)
{
    // look to see if a student is already registered in a course
    // search for the student in the course student list
    if (course.GetStudentInCourse(student.StudentId) == null)
    {
        // if not, add that student to the course's student list
        // set the course as the student's currently registered course
        course.AddStudentToCourse(student);

        // set the course as the student's currently registered course
        student.Course = course;
        student.DateRegistered = DateTime.Now;
    }
    else
    {
        throw new Exception($"Student with id {student.StudentId} already " +
            $"registered in Course {course.CourseId}");
    }
}
void deregisterStudent(Student student, Course course)
{
    if (student.Course.CourseId == course.CourseId
        && course.GetStudentInCourse(student.StudentId) == student)
    {
        course.RemoveStudentFromCourse(student);
        student.Course = null;
        student.RemoveGrade();
        student.DateRegistered = null;
    }
    else
    {
        throw new Exception($"Student with id {student.StudentId} isn't " +
            $"registered in Course {course.CourseId}");
    }
}