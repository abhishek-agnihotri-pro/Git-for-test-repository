using System.Data;
interface IEnrollmentRepository
{
    DataSet GetAllEnrollment();
    int AddEnrollment(Enrollment enrollment);
}