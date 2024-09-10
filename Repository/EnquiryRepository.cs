using System.Data;
using System.Data.SqlClient;

class EnquiryRepository : IEnquiryRepository
{
    static SqlConnection con;
    static SqlCommand cmd;
    static SqlDataAdapter da;
    static DataSet ds;
    static DataTable dt;

    public EnquiryRepository()
    {
        string connection = "Data Source=YISC1100953LT\\SQLEXPRESS; initial catalog=EDUHUBBB;integrated security=true;trustservercertificate=true";
        con = new SqlConnection(connection);
        cmd = new SqlCommand();
        cmd.Connection = con;
    }

    public int AddEnquiry(Enquiry enquiry)
    {
        try{

            cmd.CommandText = "INSERT INTO Enquiry (userId, courseId, subject, message, enquiryDate, status, response) VALUES (@userId, @courseId, @subject, @message, @enquiryDate, @status, @response)";
            cmd.Parameters.AddWithValue("@userId",enquiry.UserId);
            cmd.Parameters.AddWithValue("@courseId",enquiry.CourseId);
            cmd.Parameters.AddWithValue("@subject",enquiry.Subject);
            cmd.Parameters.AddWithValue("@message",enquiry.Message);
            cmd.Parameters.AddWithValue("@enquiryDate",enquiry.EnquiryDate);
            cmd.Parameters.AddWithValue("@status",enquiry.Status);
            cmd.Parameters.AddWithValue("@response",enquiry.Response);

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

    public DataSet GetAllEnquiry()
    {
        cmd.CommandText = "select * from enquiry";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    public bool GetEnquiryDetailsByCourseId(int id)
    {
        bool enquiriesFound = false;
        try
        {
        cmd.Parameters.Clear();
        cmd.CommandText="Select enquiryid,userid,courseid,subject,message,enquirydate,status,response from enquiry where courseid=@id";
        cmd.Parameters.AddWithValue("@id",id);
        con.Open();
        SqlDataReader sdr=cmd.ExecuteReader();
        while(sdr.Read()){
        enquiriesFound = true;
        System.Console.WriteLine($"{sdr[0]} - {sdr[1]} - {sdr[2]} - {sdr[3]} - {sdr[4]} - {sdr[5]} - {sdr[6]} - {sdr[7]}");
        }
        }
        catch (Exception ex)
        {
           System.Console.WriteLine(ex.Message);
        }
        finally{
            con.Close();
        }
        return enquiriesFound;
    }
    public int UpdateStatus(int enquiryid, string newStatus)
    {
        cmd.Parameters.Clear();
        cmd.CommandText="update enquiry set status=@newstatus where enquiryid=@enquiryid";
        cmd.Parameters.AddWithValue("@enquiryid",enquiryid);
        cmd.Parameters.AddWithValue("@newstatus",newStatus);
        con.Open();
        int rowsAffected=cmd.ExecuteNonQuery();
        con.Close();
        return rowsAffected;
    }
    public int UpdateResponse(int enquiryid, string newResponse)
    {
        cmd.Parameters.Clear();
        cmd.CommandText="update enquiry set response=@newresponse where enquiryid=@enquiryid";
        cmd.Parameters.AddWithValue("@enquiryid",enquiryid);
        cmd.Parameters.AddWithValue("@newresponse",newResponse);
        con.Open();
        int rowsAffected=cmd.ExecuteNonQuery();
        con.Close();
        return rowsAffected;
    }
}