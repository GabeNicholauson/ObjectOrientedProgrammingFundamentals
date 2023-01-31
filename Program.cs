using System;
using ObjectOrientedProgrammingFundamentals;

HashSet<Enrolment> allEnrolements = new HashSet<Enrolment>();
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
    Console.WriteLine(Jimmy.Course.Course.Title);
    Console.WriteLine(Jimmy.Course.Id);
    Console.WriteLine(Jimmy.Course.FirstName);
    Console.WriteLine(Jimmy.Course.LastName);
    Console.WriteLine(Jimmy.Course.CourseGrade);
    Console.WriteLine(Jimmy.Course.DateRegistered);
    Console.WriteLine(allEnrolements.Count);
    Console.WriteLine(Software.GetStudentInCourse(Jimmy.StudentId).FirstName);
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
        Enrolment enrolement = new Enrolment(student.StudentId, student.FirstName, student.LastName, course, student.CourseGrade, DateTime.Now);
        allEnrolements.Add(enrolement);
        course.AddStudentToCourse(enrolement);

        // set the course as the student's currently registered course
        student.Course = enrolement;
        student.DateRegistered = enrolement.DateRegistered;
    }
    else
    {
        throw new Exception($"Student with id {student.StudentId} already " +
            $"registered in Course {course.CourseId}");
    }
}