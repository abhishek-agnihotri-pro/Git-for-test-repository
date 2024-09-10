using System.Data;
using System.Data.SqlClient;

class FeedbackRepository : IFeedbackRepository
{
    static SqlConnection con;
    static SqlCommand cmd;
    static SqlDataAdapter da;
    static DataSet ds;
    static DataTable dt;

    public FeedbackRepository()
    {
        string connection = "Data Source=YISC1100953LT\\SQLEXPRESS; initial catalog=EDUHUBBB;integrated security=true;trustservercertificate=true";
        con = new SqlConnection(connection);
        cmd = new SqlCommand();
        cmd.Connection = con;
    }

    public int AddFeedback(Feedback feedback)
    {
        try{
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Feedback (userId, feedback, date) VALUES (@userId, @feedback, @date)";
            cmd.Parameters.AddWithValue("@userId",feedback.UserId);
            cmd.Parameters.AddWithValue("@feedback",feedback.feedback);
            cmd.Parameters.AddWithValue("@date",feedback.Date);

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

    public DataSet GetAllFeedback()
    {
        cmd.Parameters.Clear();
        cmd.CommandText = "select * from feedback";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
}