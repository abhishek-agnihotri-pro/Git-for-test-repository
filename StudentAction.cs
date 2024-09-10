using System.Data;
using System.Data.SqlClient;

class StudentAction
{
    static DataSet ds;
    static DataTable dt;
    public static void StudnetSequence(){
    UserRepository userRepository=new();
    System.Console.WriteLine("----------Sign In---------");
    System.Console.WriteLine("Enter Username:");
    string? username=Console.ReadLine();
    System.Console.WriteLine("Enter Password:");
    string? passowrd=Console.ReadLine();
    User user=userRepository.LoginUser(username,passowrd);
    CourseRepository courseRepository=new();
    bool flag=true;
    while(flag){
        System.Console.WriteLine("Press 1 to submit enquiry\nPress 2 to see Course Availabe\nPress 3 to See My Enrollments\nPress 4 to Enroll for Course\nPress 5 to ADD feedbacks");
        int ops=Convert.ToInt32(Console.ReadLine());
        switch(ops)
        {
            case 1:
                EnquiryRepository er = new EnquiryRepository();
                Enquiry enquiry = new Enquiry();
                Console.WriteLine("Enter User id");
                enquiry.UserId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Course id");
                enquiry.CourseId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Subject");
                enquiry.Subject = Console.ReadLine();
                Console.WriteLine("Enter status");
                enquiry.Status = Console.ReadLine();
                Console.WriteLine("Enter Message");
                enquiry.Message = Console.ReadLine();
                Console.WriteLine("Enter Response");
                enquiry.Response = Console.ReadLine();
                enquiry.EnquiryDate = DateTime.Now;
                er.AddEnquiry(enquiry);
                System.Console.WriteLine("---------Enquiry Added----------");
                break;
            case 2:
                Course newcourse=new();
                ds = courseRepository.GetAllCourses();
                foreach(DataRow row in ds.Tables[0].Rows){
                    Console.WriteLine($"{row["courseId"]} - {row["title"]} - {row["description"]}");
                }
                break;
            case 3:
                // Enrollment e = new Enrollment();
                EnrollmentRepository err = new EnrollmentRepository();
                ds = err.GetEnrollmentByUserID(user.UserId);
                foreach(DataRow row in ds.Tables[0].Rows){
                    Console.WriteLine($"{row["courseId"]} - {row["userId"]} - {row["EnrollmentDate"]} - {row["status"]}");
                }
                break;

            case 4:
                EnrollmentRepository enrollment_repo = new EnrollmentRepository();
                Enrollment enrollment = new Enrollment();
                Console.WriteLine("Enter User id");
                enrollment.UserId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Course id");
                enrollment.CourseId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Enrollment Date");
                enrollment.EnrollmentDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter Status");
                enrollment.Status = Console.ReadLine();
                enrollment.Status = "Pending";
                enrollment_repo.AddEnrollment(enrollment);
                Console.WriteLine("---------Enquiry Added----------");

                break;
            case 5:
                FeedbackRepository feedbackRepository=new ();
                Feedback f = new Feedback();
                Console.WriteLine("Enter User id");
                f.UserId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Feedback Title");
                f.feedback = Console.ReadLine();
                f.Date = DateTime.Now;
                feedbackRepository.AddFeedback(f);
                break;
            

            default:
                break;
        }
   }
    
    }
}