using System.Data;
interface IFeedbackRepository
{
    DataSet GetAllFeedback();
    int AddFeedback(Feedback feedback);
}