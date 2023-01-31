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
    Console.WriteLine(Jimmy.Enrolment.Course.Title);
    Console.WriteLine(Jimmy.Enrolment.Id);
    Console.WriteLine(Jimmy.Enrolment.RegisteredStudent.StudentId);
    Console.WriteLine(Jimmy.Enrolment.RegisteredStudent.FirstName);
    Console.WriteLine(Jimmy.Enrolment.RegisteredStudent.LastName);
    Console.WriteLine(Jimmy.Enrolment.CourseGrade);
    Console.WriteLine(Jimmy.Enrolment.DateRegistered);
    Console.WriteLine(allEnrolements.Count);
    Console.WriteLine(Software.GetStudentInCourse(Jimmy.StudentId).RegisteredStudent.FirstName);

    deregisterStudent(Jimmy, Software);
    Console.WriteLine(Software.GetStudentInCourse(Jimmy.StudentId));
    Console.WriteLine(Jimmy.Enrolment);
    Console.WriteLine(allEnrolements.Count);
    Console.WriteLine(Jimmy.DateRegistered);
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
        Enrolment enrolement = new Enrolment(2132, student, course, 0, DateTime.Now);
        allEnrolements.Add(enrolement);
        course.AddStudentToCourse(enrolement);

        // set the course as the student's currently registered course
        student.Enrolment = enrolement;
        student.DateRegistered = enrolement.DateRegistered;
    }
    else
    {
        throw new Exception($"Student with id {student.StudentId} already " +
            $"registered in Course {course.CourseId}");
    }
}

void deregisterStudent(Student student, Course course)
{
    if (student.Enrolment != null && student.Enrolment.Course.CourseId == course.CourseId
        && course.GetStudentInCourse(student.StudentId).RegisteredStudent.FirstName == student.FirstName)
    {
        foreach(Enrolment e in allEnrolements)
        {
            if (e.DateRegistered == student.DateRegistered)
            {
                course.RemoveStudentFromCourse(e);
                break;
            }
        }
        student.Enrolment = null;
        student.RemoveGrade();
        student.DateRegistered = null;
    }
    else
    {
        throw new Exception($"Student with id {student.StudentId} isn't " +
            $"registered in Course {course.CourseId}");
    }
}