using System.Data;
using System.Data.SqlClient;

class EnrollmentRepository : IEnrollmentRepository
{
    static SqlConnection con;
    static SqlCommand cmd;
    static SqlDataAdapter da;
    static DataSet ds;
    static DataTable dt;

    public EnrollmentRepository()
    {
        string connection = "Data Source=YISC1100953LT\\SQLEXPRESS; initial catalog=EDUHUBBB;integrated security=true;trustservercertificate=true";
        con = new SqlConnection(connection);
        cmd = new SqlCommand();
        cmd.Connection = con;
    }

    public int AddEnrollment(Enrollment enrollment)
    {
        try{
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Enrollment (userId, courseId, enrollmentDate, status) VALUES (@userId, @courseId, @enrollmentDate, @status)";
            cmd.Parameters.AddWithValue("@userId",enrollment.UserId);
            cmd.Parameters.AddWithValue("@courseId",enrollment.CourseId);
            cmd.Parameters.AddWithValue("@enrollmentDate",enrollment.EnrollmentDate);
            cmd.Parameters.AddWithValue("@status",enrollment.Status);

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

    public DataSet GetAllEnrollment()
    {
        cmd.Parameters.Clear();
        cmd.CommandText = "select * from enrollment";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    public DataSet GetEnrollmentByUserID(int id)
    {
        cmd.Parameters.Clear();
        cmd.CommandText = "select * from enrollment where userid = @id";
        cmd.Parameters.AddWithValue("@id",id);
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
}