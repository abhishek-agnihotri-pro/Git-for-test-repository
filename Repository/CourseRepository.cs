using System.Data;
using System.Data.SqlClient;

class CourseRepository : ICourseRepository
{
    static SqlConnection con;
    static SqlCommand cmd;
    static SqlDataAdapter da;
    static DataSet ds;
    static DataTable dt;

    public CourseRepository()
    {
        string connection = "Data Source=YISC1100953LT\\SQLEXPRESS; initial catalog=EDUHUBBB;integrated security=true;trustservercertificate=true";
        con = new SqlConnection(connection);
        cmd = new SqlCommand();
        cmd.Connection = con;
    }

    public int AddCourse(Course course)
    {
        try{

            // if(IsUserExists(new_user.UserName)){
            //     Console.WriteLine("User Already Exists");
            //     return 0;
            // } 
            cmd.Parameters.Clear();
            cmd.CommandText = "exec SP_AddCourse @title, @description, @courseStartDate, @courseEndDate, @userId, @category, @level";
            cmd.Parameters.AddWithValue("@title",course.title);
            cmd.Parameters.AddWithValue("@description",course.description);
            cmd.Parameters.AddWithValue("@courseStartDate",course.courseStartDate);
            cmd.Parameters.AddWithValue("@courseEndDate",course.courseEndDate);
            cmd.Parameters.AddWithValue("@userId",course.userId);
            cmd.Parameters.AddWithValue("@category",course.category);
            cmd.Parameters.AddWithValue("@level",course.level);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            return result;
        }
        catch(SqlException ex){
            Console.WriteLine(ex.Message);
        }
        return 0;
    }

    public DataSet GetAllCourses()
    {
        cmd.Parameters.Clear();
        cmd.CommandText = "exec SP_GetAllCourses";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    public DataSet GetCoursesByUserId(int userId)
    {
        cmd.Parameters.Clear();
        cmd.CommandText = "select * from courses where userid = @userId";
        cmd.Parameters.AddWithValue("@userId",userId);
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    public int UpdateCourse(Course course)
    {
        try{
            cmd.Parameters.Clear();
            cmd.CommandText = "exec SP_UpdateCourse @title, @description, @courseStartDate, @courseEndDate, @userId, @category, @level,@courseId";
            cmd.Parameters.AddWithValue("@title",course.title);
            cmd.Parameters.AddWithValue("@description",course.description);
            cmd.Parameters.AddWithValue("@courseStartDate",course.courseStartDate);
            cmd.Parameters.AddWithValue("@courseEndDate",course.courseEndDate);
            cmd.Parameters.AddWithValue("@userId",course.userId);
            cmd.Parameters.AddWithValue("@category",course.category);
            cmd.Parameters.AddWithValue("@level",course.level);
            cmd.Parameters.AddWithValue("@courseId",course.courseId);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        catch(SqlException ex){
            Console.WriteLine(ex.Message);
        }
        return 0;
    }
    public bool IsCourseExists(int courseId){
        cmd.Parameters.Clear();
        cmd.CommandText = "select count(courseId) from courses where courseId = @courseId";
        cmd.Parameters.AddWithValue("@courseId",courseId);
        con.Open();
        int res = (int)cmd.ExecuteScalar();
        con.Close();
        if(res > 0) return true;
        else return false;

    }

    // public bool CourseExistByTitle(string Title)
    // {
    //     cmd.Parameters.Clear();
    //     cmd.CommandText="SP_CountofCoursettitle";
    //     cmd.Parameters.AddWithValue("@title",Title);
    //     con.Open();
    //     int result=(int)cmd.ExecuteScalar();
    //     con.Close();
    //     if(result==1){
    //         return true;
    //     }
    //     else return false;
    // }
}