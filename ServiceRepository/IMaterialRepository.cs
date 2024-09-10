using System.Data;
interface IMaterialRepository
{
    DataSet GetAllMaterial();
    // User GetUserById(int id);
    // bool IsUserExists(string userName);
    int AddMaterial(Material material);
}