using System.Data;

class Program
{
    public static void Main(string[] args){

        Console.Write("Press 1 to start as Student or Press 2 for Teacher : ");
        int navigate = Convert.ToInt32(Console.ReadLine());
        
        switch(navigate){
            case 1:
                StudentAction.StudnetSequence();
                break;
            case 2:
                TeacherAction.TeacherSequence();
                break;

        }

        // Console.Write("Press 1 for Navigation with Users or Press 2 for Courses : ");
//         int navigate = Convert.ToInt32(Console.ReadLine());
        
//         switch(navigate){
//             case 1:
//                 UserRepository Repo = new UserRepository();
//                 DataSet ds;
//                 User user;

//                 while(true){
//                     Console.WriteLine("Enter 1 to retrieve All Users,");
//                     Console.WriteLine("Enter 2 to check User Existence,");
//                     Console.WriteLine("Enter 3 to Add User,");
//                     Console.WriteLine("Enter 4 to Edit User,");
//                     Console.WriteLine("Enter 5 to Login User,");
//                     Console.WriteLine("Enter -1 to exit application.");

//                     int flag = 0;
//                     flag = Convert.ToInt32(Console.ReadLine());
//                     switch(flag){
//                         case 1 :
//                             ds = Repo.GetAllUsers();
//                             foreach(DataRow row in ds.Tables[0].Rows){
//                                 Console.WriteLine($"{row["userId"]} = {row["username"]}");
//                             }
                            
//                             break;

//                         case 2 :
//                             // int id = 2;
//                             // Repo.IsUserExists(id);
//                             break;


//                         case 3:
//                             Console.WriteLine("Enter User Details");
//                             user = new User();

//                             bool not_unique = true;
//                             while(not_unique){
//                                 Console.Write("Name : ");
//                                 user.UserName = Console.ReadLine();
//                                 if(Repo.IsUserExists(user.UserName)){
//                                     Console.WriteLine("User Already Exists");
//                                     not_unique = true;
//                                 }
//                                 else not_unique = false;
//                             }
//                             Console.Write("Password : ");
//                             user.Password = Console.ReadLine();
//                             Console.Write("Email : ");
//                             user.Email = Console.ReadLine();
//                             Console.Write("Role : ");
//                             user.UserRole = Console.ReadLine();
//                             Console.Write("Profile Image URL : ");
//                             user.ProfileImage = Console.ReadLine();
//                             Console.Write("Mobile Number : ");
//                             user.MobileNumber = Console.ReadLine();
//                             int res = Repo.AddUser(user);
//                             if(res > 0){
//                                 int newly_generated_userid = Repo.GetNewUserID();
//                                 Console.WriteLine($"User Added Successfully with id : {newly_generated_userid}");
//                             } 
//                             else Console.WriteLine("Something went wrong");
//                             break;
                        
//                         case 4 :
//                             Console.WriteLine("Edit profile");
//                             user = new User();
//                             Console.Write("Enter username to Edit User : ");
//                             user.UserName = Console.ReadLine();
//                             if(!Repo.IsUserExists(user.UserName)){
//                                 Console.WriteLine($"User Does not exist with {user.UserName}");
//                                 break;
//                             }
//                             Console.Write("Email : ");
//                             user.Email = Console.ReadLine();
//                             Console.Write("Profile Image URL : ");
//                             user.ProfileImage = Console.ReadLine();
//                             Console.Write("Mobile Number : ");
//                             user.MobileNumber = Console.ReadLine();
//                             int ress = Repo.UpdateProfile(user);
//                             if(ress > 0) Console.WriteLine("User Edited Successfully");
//                             else Console.WriteLine("Something went wrong");

//                             break;

//                         case 5:
//                             Console.Write("Username : ");
//                             string ?username = Console.ReadLine();
//                             Console.Write("Password : ");
//                             string ?password = Console.ReadLine();
//                             User returned_user = Repo.LoginUser(username,password);
//                             if(returned_user == null){
//                             Console.WriteLine($"Invalid Credentials");
//                             }
//                             else
//                             Console.WriteLine($"{returned_user.UserName}");
//                             break;

//                         case -1:
//                             Console.WriteLine("See you Soon");
//                             break;
                            
//                         default :
//                             Console.WriteLine("Invalid input");
//                             break;
                        
//                     }
//                     Console.Write("Do you want to continue : (Y/N)");
//                     char YN = Convert.ToChar(Console.ReadLine());
//                     if(YN == 'N'){
//                         break;
//                     }
                    
//                 }

//             break;
//             case 2:
//                 CourseRepository course_repo = new CourseRepository();
//                 // DataSet ds;
//                 Course course;

//                 while(true){
//                     Console.WriteLine("Enter 1 to retrieve All Courses,");
//                     Console.WriteLine("Enter 2 to check Course Existence,");
//                     Console.WriteLine("Enter 3 to Add Course,");
//                     Console.WriteLine("Enter 4 to Edit Course,");
//                     Console.WriteLine("Enter 5 to Get Courses By UserID,");
//                     Console.WriteLine("Enter -1 to exit application.");

//                     int flag = 0;
//                     flag = Convert.ToInt32(Console.ReadLine());
//                     switch(flag){
//                         case 1 :
//                             ds = course_repo.GetAllCourses();
//                             foreach(DataRow row in ds.Tables[0].Rows){
//                                 Console.WriteLine($"{row["courseId"]} = {row["title"]}");
//                             }
                            
//                             break;

//                         case 2 :
//                             // int id = 2;
//                             // Repo.IsUserExists(id);
//                             break;


//                         case 3:
//                             Console.WriteLine("Enter Course Details");
//                             course = new Course();

//                             bool not_unique = true;
//                             while(not_unique){
//                                 Console.Write("Title : ");
//                                 course.title = Console.ReadLine();
//                                 if(course_repo.IsCourseExists(course.courseId)){
//                                     Console.WriteLine("Course Already Exists");
//                                     not_unique = true;
//                                 }
//                                 else not_unique = false;
//                             }
//                             Console.Write("Description : ");
//                             course.description = Console.ReadLine();
//                             Console.Write("Course Start Date : ");
//                             course.courseStartDate = Convert.ToDateTime(Console.ReadLine());
//                             Console.Write("Course End Date : ");
//                             course.courseEndDate = Convert.ToDateTime(Console.ReadLine());
//                             Console.Write("User ID : ");
//                             course.userId = Convert.ToInt32(Console.ReadLine());
//                             Console.Write("Category : ");
//                             course.category = Console.ReadLine();
//                             Console.Write("Level : ");
//                             course.level = Console.ReadLine();
//                             int res = course_repo.AddCourse(course);
//                             if(res > 0){
//                                 // int newly_generated_userid = course_repo.GetNewUserID();
//                                 // Console.WriteLine($"Course Added Successfully with id : {newly_generated_userid}");
//                             } 
//                             else Console.WriteLine("Something went wrong");
//                             break;
                        
//                         case 4 :
//                             Console.WriteLine("Edit a Course");
//                             course = new Course();
//                             Console.Write("Enter CourseId to Edit Course : ");
//                             course.courseId = Convert.ToInt32(Console.ReadLine());
//                             if(!course_repo.IsCourseExists(course.courseId)){
//                                 Console.WriteLine($"Course Does not exist with {course.courseId}");
//                                 break;
//                             }
//                             Console.Write("Title : ");
//                             course.title = Console.ReadLine();
//                             Console.Write("Description : ");
//                             course.description = Console.ReadLine();
//                             Console.Write("Course Start Date : ");
//                             course.courseStartDate = Convert.ToDateTime(Console.ReadLine());
//                             Console.Write("Course End Date : ");
//                             course.courseEndDate = Convert.ToDateTime(Console.ReadLine());
//                             Console.Write("User ID : ");
//                             course.userId = Convert.ToInt32(Console.ReadLine());
//                             Console.Write("Category : ");
//                             course.category = Console.ReadLine();
//                             Console.Write("Level : ");
//                             course.level = Console.ReadLine();
//                             int ress = course_repo.UpdateCourse(course);
//                             if(ress > 0) Console.WriteLine("Course Edited Successfully");
//                             else Console.WriteLine("Something went wrong");

//                             break;

//                         case 5:
//                             Console.Write("Enter User id to retreive registered courses : ");
//                             int userId = Convert.ToInt32(Console.ReadLine());
//                             ds = course_repo.GetCoursesByUserId(userId);
//                             foreach(DataRow row in ds.Tables[0].Rows){
//                                 Console.WriteLine($"{row["courseId"]} = {row["title"]}");
//                             }
//                             break;

//                         case -1:
//                             Console.WriteLine("See you Soon");
//                             break;
                            
//                         default :
//                             Console.WriteLine("Invalid input");
//                             break;
                        
//                     }
//                     Console.Write("Do you want to continue : (Y/N)");
//                     char YN = Convert.ToChar(Console.ReadLine());
//                     if(YN == 'N'){
//                         break;
//                     }
                    
//                 }
//             break;
//             default:
//             break;
//         }
    }
}