using System.Data;
using System.Data.SqlClient;

class MaterialRepository : IMaterialRepository
{
    static SqlConnection con;
    static SqlCommand cmd;
    static SqlDataAdapter da;
    static DataSet ds;
    static DataTable dt;

    public MaterialRepository()
    {
        string connection = "Data Source=YISC1100953LT\\SQLEXPRESS; initial catalog=EDUHUBBB;integrated security=true;trustservercertificate=true";
        con = new SqlConnection(connection);
        cmd = new SqlCommand();
        cmd.Connection = con;
    }

    public int AddMaterial(Material material)
    {
        try{
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Material (courseId, title, description, URL, uploadDate, contentType) VALUES (@courseId,@title,@description, @URL, @uploadDate, @contentType)";
            cmd.Parameters.AddWithValue("@courseId",material.courseId);
            cmd.Parameters.AddWithValue("@title",material.title);
            cmd.Parameters.AddWithValue("@description",material.description);
            cmd.Parameters.AddWithValue("@URL",material.url);
            cmd.Parameters.AddWithValue("@uploadDate",material.uploadDate);
            cmd.Parameters.AddWithValue("@contentType",material.contentType);

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

    public DataSet GetAllMaterial()
    {
        cmd.Parameters.Clear();
        cmd.CommandText = "select * from material";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
}