using System.Data;
using System.Data.SqlClient;

class TeacherAction
{
    static DataSet ds;
    static DataTable dt;
    public static void TeacherSequence(){
    UserRepository userRepository=new();
    System.Console.WriteLine("----------LogIn---------");
    System.Console.WriteLine("Enter Username:");
    string? username=Console.ReadLine();
    System.Console.WriteLine("Enter Password:");
    string? passowrd=Console.ReadLine();
    User user=userRepository.LoginUser(username,passowrd);
    CourseRepository courseRepository=new();
    bool flag=true;
    while(flag){
        System.Console.WriteLine("Press 1 to see all courses\nPress 2 to add new courses\nPress 3 to add new material\nPress 4 to see enquiry list\nPress 5 to see feedbacks");
        int ops=Convert.ToInt32(Console.ReadLine());
        switch(ops)
        {
            case 1:
                int user_Id = user.UserId;
                ds = courseRepository.GetCoursesByUserId(user_Id);
                foreach(DataRow row in ds.Tables[0].Rows){
                    Console.WriteLine($"{row["courseId"]} - {row["title"]} - {row["description"]}");
                }
                break;
            case 2:
            Course newcourse=new();
            System.Console.WriteLine("Enter course title to add");
            string? title=Console.ReadLine();

                newcourse.title=title;
                System.Console.WriteLine("Enter course desc:");
                newcourse.description=Console.ReadLine();
                System.Console.WriteLine("Enter course startdate");
                newcourse.courseStartDate=Convert.ToDateTime(Console.ReadLine());
                System.Console.WriteLine("Enter course enddate");
                newcourse.courseEndDate=Convert.ToDateTime(Console.ReadLine());
                System.Console.WriteLine("Enter Educator's Userid");
                newcourse.userId=user.UserId;
                System.Console.WriteLine("Enter course category");
                newcourse.category=Console.ReadLine();
                System.Console.WriteLine("Enter course difficulty level");
                newcourse.level=Console.ReadLine();
                courseRepository.AddCourse(newcourse);
                System.Console.WriteLine("---------Course Added----------");

            break;
            case 3:
                MaterialRepository materialRepository=new();
                Material newmaterial=new();
                System.Console.WriteLine("Enter courseid:");
                newmaterial.courseId=Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Enter title:");
                newmaterial.title=Console.ReadLine();
                System.Console.WriteLine("Enter description:");
                newmaterial.description=Console.ReadLine();
                newmaterial.uploadDate=DateTime.Now;
                System.Console.WriteLine("Enter content type:");
                newmaterial.contentType=Console.ReadLine();
                System.Console.WriteLine("Enter content URL:");
                newmaterial.url=Console.ReadLine();
                materialRepository.AddMaterial(newmaterial);
            break;

            case 4:
            System.Console.WriteLine("Enter course id to check enquiries");
            int courseid=Convert.ToInt32(Console.ReadLine());
            EnquiryRepository enquiryRepository =new();
            bool enquiriesFound = enquiryRepository.GetEnquiryDetailsByCourseId(courseid);
            if (enquiriesFound)
            {
            Console.WriteLine("Want to update status or response?\nPress 1 for updating status\nPress 2 for updating response");
            string response = Console.ReadLine();
            if (response == "1")
            {
                Console.WriteLine("Enter enquiry id");
                int enquiryid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter status");
                string status = Console.ReadLine();
                int result = enquiryRepository.UpdateStatus(enquiryid, status);
            Console.WriteLine("Status updated");
            }
            else if (response == "2")
            {
                Console.WriteLine("Enter enquiry id");
                int enquiryid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter response");
                string newresponse = Console.ReadLine();
                int result1 = enquiryRepository.UpdateResponse(enquiryid, newresponse);
                Console.WriteLine("Response updated");
            }
        }
        else
        {
            Console.WriteLine("No enquiries found for the given course ID.");
        }
        break;

            case 5:
                FeedbackRepository feedbackRepository=new ();
                ds = feedbackRepository.GetAllFeedback();;
                foreach(DataRow row in ds.Tables[0].Rows){
                    Console.WriteLine($"{row["userId"]} - {row["feedback"]} - {row["date"]}");
                }
                break;
            

            default:
                break;
        }
   }
    
    }
}