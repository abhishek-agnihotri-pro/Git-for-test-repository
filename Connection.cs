using System.Data;
using System.Data.SqlClient;

public class Connection{
    public SqlConnection con;
    public SqlCommand cmd;
    public SqlDataAdapter da;

    public Connection()
    {
        string connection = "Data Source=YISC1100953LT\\SQLEXPRESS; initial catalog=EDUHUBBB;integrated security=true;trustservercertificate=true";
        con = new SqlConnection(connection);
        cmd = new SqlCommand();
        cmd.Connection = con;
    }
}