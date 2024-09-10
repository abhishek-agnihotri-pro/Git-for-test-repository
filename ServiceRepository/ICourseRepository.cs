using System.Data;

interface ICourseRepository
{
    DataSet GetAllCourses();
    DataSet GetCoursesByUserId(int userIdid);
    int AddCourse(Course course);
    int UpdateCourse(Course course);
}