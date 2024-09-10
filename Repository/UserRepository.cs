using System.Data;
using System.Data.SqlClient;


class UserRepository : IUserRepository
{
    static SqlConnection con;
    static SqlCommand cmd;
    static SqlDataAdapter da;
    static DataSet ds;
    static DataTable dt;

    public UserRepository()
    {
        string connection = "Data Source=YISC1100953LT\\SQLEXPRESS; initial catalog=EDUHUBBB;integrated security=true;trustservercertificate=true";
        con = new SqlConnection(connection);
        cmd = new SqlCommand();
        cmd.Connection = con;
    }
    public DataSet GetAllUsers()
    {
        cmd.CommandText = "select userid,username from users";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    public DataSet GetAllStudents()
    {
        cmd.CommandText = "select userid,username from users where role = 'student' ";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    public DataSet GetAllTeachers()
    {
        cmd.CommandText = "select userid,username from users where role = 'student' ";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    public int UpdateProfile(User user){
        try{
            cmd.Parameters.Clear();
            cmd.CommandText = "update users set email=@email,mobile_number = @mobile, profileImage=@profileImage where username = @username";
            cmd.Parameters.AddWithValue("@email",user.Email);
            cmd.Parameters.AddWithValue("@mobile",user.MobileNumber);
            cmd.Parameters.AddWithValue("@profileimage",user.ProfileImage);
            cmd.Parameters.AddWithValue("@username",user.UserName);
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
    public int GetNewUserID(){
        cmd.Parameters.Clear();
        cmd.CommandText = "select max(userId) from users";
        con.Open();
        int Id = (int)cmd.ExecuteScalar();
        con.Close();
        return Id;
    }
    public bool IsUserExists(string userName)
    {
        try{
            cmd.Parameters.Clear();
            cmd.CommandText = "select count(username) from users where username = @userName";
            cmd.Parameters.AddWithValue("@userName",userName);
            con.Open();
            int res = (int)cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            con.Close();
            if(res == 1) return true;
            else return false;
        }
        catch(SqlException ex){
            Console.WriteLine(ex);
        }
        return false;
    }
    public int AddUser(User new_user){
        try{

            // if(IsUserExists(new_user.UserName)){
            //     Console.WriteLine("User Already Exists");
            //     return 0;
            // } 
            cmd.Parameters.Clear();
            cmd.CommandText = "insert into users(username,password,email,mobile_number,role,profileImage) values(@username,@password,@email,@mobile_number,@role,@profileImage)";
            cmd.Parameters.AddWithValue("@username",new_user.UserName);
            cmd.Parameters.AddWithValue("@password",new_user.Password);
            cmd.Parameters.AddWithValue("@mobile_number",new_user.MobileNumber);
            cmd.Parameters.AddWithValue("@role",new_user.UserRole);
            cmd.Parameters.AddWithValue("@profileImage",new_user.ProfileImage);
            cmd.Parameters.AddWithValue("@email",new_user.Email);
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

    public User LoginUser(string ?username, string ?password){
        cmd.Parameters.Clear();
        cmd.CommandText = "select * from users where username = @username and password = @password";
        cmd.Parameters.AddWithValue("@username",username);
        cmd.Parameters.AddWithValue("@password",password);
        User user = new User();
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        dt = ds.Tables[0];
        if(dt.Rows.Count == 1){
            user.UserId = (int)dt.Rows[0]["userId"];
            user.UserName = (string)dt.Rows[0]["username"];
            user.Password = (string)dt.Rows[0]["password"];
            return user; 
        }
        else return user;

    }
}