using System.Data;
interface IEnquiryRepository
{
    DataSet GetAllEnquiry();
    int AddEnquiry(Enquiry enquiry);
}