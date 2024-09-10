using System.Data;

interface IUserRepository
{
    DataSet GetAllUsers();
    // User GetUserById(int id);
    bool IsUserExists(string userName);
    int AddUser(User new_user);
    int GetNewUserID();
    User LoginUser(string username, string password);
}