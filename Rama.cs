using System;
using System.IO;

// ==================== Member Classes ====================

public class Member
{
    // Set & get member
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string JoinDate { get; set; } = "";

    // Member constructor
    public Member(int id, string name, string email, string joinDate)
    {
        Id = id;
        Name = name;
        Email = email;
        JoinDate = joinDate;
    }

    // Soon...
    public virtual double CalculateMonthlyFee()
    {
        // Monthly fees
        return 0;
    }

    // Print member information
    public virtual void PrintInfo()
    {
        Console.WriteLine($"ID: {Id} | Name: {Name} | Email: {Email} | Join Date: {JoinDate} | Monthly Fee: {CalculateMonthlyFee()}");
    }
}

// Inherit from Member class for standerd members
public class StandardMember : Member
{
    public int FreezeDaysUsed { get; set; }

    // Standard member constructor
    public StandardMember(int id, string name, string email, string joinDate, int freezeDaysUsed) : base(id, name, email, joinDate)
    {
        this.FreezeDaysUsed = freezeDaysUsed;
    }

    // Print standard member information
    public override void PrintInfo()
    {
        Console.WriteLine($"[STANDARD] ID: {Id} | Name: {Name} | Email: {Email} | Join Date: {JoinDate} | Freeze Days Used: {FreezeDaysUsed}");
    }
}

// Inherit from Member class for premium members
public class PremiumMember : Member
{
    public bool HasPersonalTrainer { get; set; }
    public int GuestPasses { get; set; }

    // Premium member constructor
    public PremiumMember(int id, string name, string email, string joinDate, bool hasPersonalTrainer, int guestPasses) : base(id, name, email, joinDate)
    {
        this.HasPersonalTrainer = hasPersonalTrainer;
        this.GuestPasses = guestPasses;
    }

    // Print premium member info
    public override void PrintInfo()
    {
        Console.WriteLine($"[PREMIUM] ID: {Id} | Name: {Name} | Email: {Email} | Join Date: {JoinDate} | Personal Trainer: {HasPersonalTrainer} | Guest Passes: {GuestPasses}");
    }
}

// ==================== Activity Classes ====================

public class Activity
{
    // Set & get activity
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int DurationMinutes { get; set; }
    public int Capacity { get; set; }

    // Activities constructor
    public Activity(int id, string name, int durationMinutes, int capacity)
    {
        Id = id;
        Name = name;
        DurationMinutes = durationMinutes;
        Capacity = capacity;
    }

    // Print activities info
    public virtual void PrintInfo()
    {
        Console.WriteLine($"ID: {Id} | Name: {Name} | Duration: {DurationMinutes} min | Capacity: {Capacity}");
    }
}

// Inherit from Activity class for group classes
public class GroupClass : Activity
{
    public string InstructorName { get; set; } = "";
    public string DifficultyLevel { get; set; } = "";

    // Group class constructor
    public GroupClass(int id, string name, int durationMinutes, int capacity, string instructorName, string difficultyLevel) : base(id, name, durationMinutes, capacity)
    {
        this.InstructorName = instructorName;
        this.DifficultyLevel = difficultyLevel;
    }

    // print group class info
    public override void PrintInfo()
    {
        Console.WriteLine($"[GROUP] ID: {Id} | Name: {Name} | Duration: {DurationMinutes} min | Capacity: {Capacity} | Instructor: {InstructorName} | Level: {DifficultyLevel}");
    }
}

// Inherit from Activity class for personal training sessions
public class PersonalTrainingSession : Activity
{
    public int TrainerId { get; set; }
    public double HourlyRate { get; set; }

    // Personal training session constructor
    public PersonalTrainingSession(int id, string name, int durationMinutes, int capacity, int trainerId, double hourlyRate) : base(id, name, durationMinutes, capacity)
    {
        this.TrainerId = trainerId;
        this.HourlyRate = hourlyRate;
    }

    // Print personal training session info
    public override void PrintInfo()
    {
        Console.WriteLine($"[PT] ID: {Id} | Name: {Name} | Duration: {DurationMinutes} min | Capacity: {Capacity} | TrainerID: {TrainerId} | Rate: {HourlyRate}");
    }
}

/////////////////////YAZAN_START//////////////////////////////////
// ==================== Trainer Class ====================

public class Trainer
{
    public int TrainerId { get; set; }
    public string Name { get; set; } = "";
    public string Specialty { get; set; } = "";
    public double Salary { get; set; }

    // Trainer Constructor
    public Trainer(int trainerId, string name, string specialty, double salary)
    {
        TrainerId = trainerId;
        Name = name;
        Specialty = specialty;
        Salary = salary;
    }

    // Print Trainer Info
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Trainer ID: {TrainerId} | Name: {Name} | Specialty: {Specialty} | Salary: {Salary}");
    }
}

// ==================== Booking Class ====================

public class Booking
{
    public int BookingId { get; set; }
    public int MemberId { get; set; }
    public int ActivityId { get; set; }
    public string Date { get; set; } = "";
    public string Status { get; set; } = "";

    // Booking Constructor
    public Booking(int bookingId, int memberId, int activityId, string date, string status)
    {
        BookingId = bookingId;
        MemberId = memberId;
        ActivityId = activityId;
        Date = date;
        Status = status;
    }

    // Print Booking Info
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Booking ID: {BookingId} | Member ID: {MemberId} | Activity ID: {ActivityId} | Date: {Date} | Status: {Status}");
    }
}
/////////////////////YAZAN_END//////////////////////////////////

// ==================== System ====================

public class FitnessClubSystem
{
    // 50 is the max saze for arrys
    private const int MAX_MEMBERS = 50;
    private const int MAX_ACTIVITIES = 50;
    // Members arry that has 50 empty spot
    private Member[] members = new Member[MAX_MEMBERS];
    private int memberCount = 0;
    // Activities arry that has 50 empty spot
    private Activity[] activities = new Activity[MAX_ACTIVITIES];
    private int activityCount = 0;

/////////////////////YAZAN_START//////////////////////////////////
    private const int MAX_TRAINERS = 50;
    private const int MAX_BOOKINGS = 50;

    private Trainer[] trainers = new Trainer[MAX_TRAINERS];
    private int trainerCount = 0;

    private Booking[] bookings = new Booking[MAX_BOOKINGS];
    private int bookingCount = 0;
/////////////////////YAZAN_END/////////////////////////////////

    // Add members to the arry if thay are less than 50
    public void AddMember(Member member)
    {
        if (memberCount < MAX_MEMBERS)
        {
            members[memberCount++] = member;
        }
        else
        {
            Console.WriteLine("Cannot add more members. Maximum limit reached.");
        }
    }

    public void Addmemberinteractivite()
    {
        if (memberCount >= MAX_MEMBERS)
        {
            Console.WriteLine("Cannot add more members. Maximum limit reached.");
            return;
        }
        Console.WriteLine("===Add New Member===");
        Console.WriteLine("Enter Member Type (STANDARD/PREMIUM):");
        string type = Console.ReadLine();
        int id = memberCount + 1;
        Console.Write("Enter Name :");
        string name = Console.ReadLine();
        Console.Write("Enter email :");
        string email = Console.ReadLine();
        Console.Write(" Enter join Date : ");
        string joindate = Console.ReadLine();
        if(type.ToUpper()=="STANDARD")
        {
            Console.Write("Enter Freeze Days Used: ");
            int freezeDys = int.Parse(Console.ReadLine());
            StandardMember sm = new StandardMember(id, name, email, joindate, freezeDys);
            AddMember(sm);
            FileManager.SaveMember(sm);
        }
        else if(type.ToUpper()=="PREMIUM")
        {
            Console.WriteLine("Has Personal Trainer(true/false):");
            bool hasTrainer = bool.Parse(Console.ReadLine());
            Console.Write("Enter Guest Passes :");
            int passes = int.Parse(Console.ReadLine());
            PremiumMember pm = new PremiumMember(id, name, email, joindate, hasTrainer, passes);
            AddMember(pm);
            FileManager.SaveMember(pm);
            Console.WriteLine("Premium Member added successfully!:");
        }
        else
        {
            Console.WriteLine("Invalid type!");
        }
    }

    // Add activities to the arry if thay are less than 50
    public void AddActivity(Activity activity)
    {
        if (activityCount < MAX_ACTIVITIES)
        {
            activities[activityCount++] = activity;
        }
        else
        {
            Console.WriteLine("Cannot add more activities. Maximum limit reached.");
        }
    }

    public void AddActivityInteraactive()
    {
        if(activityCount >= MAX_ACTIVITIES)
        {
            Console.WriteLine("Cannot add more activity.Maximum limit reached. ");
            return;
        }
        Console.WriteLine("===Add New Activity ");
        Console.Write("Enter Activity Type (GROUP/PT):");
        string type = Console.ReadLine();
        Console.Write("Enter Activity  Name:");
        string name = Console.ReadLine();
        Console.Write("Enter Duration(Minutes):");
        int durationMinutes = int.Parse(Console.ReadLine());
        Console.Write("Enter Capacity");
        int capacity = int.Parse(Console.ReadLine());
        if(type.ToUpper()=="GROUP")
        {
            Console.Write("Enter Instructor Name:");
            string InstructorName = Console.ReadLine();
            Console.Write("Enter difficulty level:");
            string Difficultylevel= Console.ReadLine();
            int id = activityCount + 1;
            GroupClass groupClass = new GroupClass(id, name, durationMinutes, capacity, InstructorName, Difficultylevel);
            AddActivity(groupClass);
            FileManager.SaveActivity(groupClass);
          
        } else if (type.ToUpper() == "PT")
        {
            int id = activityCount + 1;

            Console.Write("Enter Trainer ID: ");
            int trainerId = int.Parse(Console.ReadLine());

            Console.Write("Enter Hourly Rate: ");
            double hourlyRate = double.Parse(Console.ReadLine());

            PersonalTrainingSession pt = new PersonalTrainingSession(
                id, name, durationMinutes, capacity, trainerId, hourlyRate
            );

            AddActivity(pt);
            FileManager.SaveActivity(pt);
        }
        else
        {
            Console.WriteLine("Invalid type!");
        }
       
    }

/////////////////////YAZAN_START//////////////////////////////////
    // Add Trainer
    public void AddTrainer(Trainer trainer)
    {
        if (trainerCount < MAX_TRAINERS)
        {
            trainers[trainerCount++] = trainer;
        }
        else
        {
            Console.WriteLine("Cannot add more trainers. Maximum limit reached.");
        }
    }

    public void AddTrainerFromUser(FileManager fileManager)
    {
        Console.Write("Enter Trainer ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Trainer Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Trainer Specialty: ");
        string specialty = Console.ReadLine();

        Console.Write("Enter Trainer Salary: ");
        double salary = double.Parse(Console.ReadLine());

        Trainer trainer = new Trainer(id, name, specialty, salary);

        AddTrainer(trainer);
        fileManager.SaveTrainer(trainer);

        Console.WriteLine("Trainer added successfully!");
    }

    // Add Booking
    public void AddBooking(Booking booking)
    {
        if (bookingCount < MAX_BOOKINGS)
        {
            bookings[bookingCount++] = booking;
        }
        else
        {
            Console.WriteLine("Cannot add more bookings. Maximum limit reached.");
        }
    }

    public void AddBookingFromUser(FileManager fileManager)
    {
        Console.Write("Enter Member ID: ");
        int memberId = int.Parse(Console.ReadLine());

        Console.Write("Enter Activity ID: ");
        int activityId = int.Parse(Console.ReadLine());

        Console.Write("Enter Booking Date (YYYY-MM-DD): ");
        string date = Console.ReadLine();

        int bookingId = bookingCount + 1;

        string status = "Confirmed";

        Booking booking = new Booking(
            bookingId,
            memberId,
            activityId,
            date,
            status
        );

        AddBooking(booking);
        fileManager.SaveBooking(booking);

        Console.WriteLine("Booking added successfully!");
    }


    /////////////////////YAZAN_END//////////////////////////////////

    // Show all members in the arry
    public void ShowAllMembers()
    {
        Console.WriteLine("=== All Members ===");
        for (int i = 0; i < memberCount; i++)
        {
            members[i].PrintInfo();
        }
    }

    // Show all the activities in the arry
    public void ShowAllActivities()
    {
        Console.WriteLine("=== All Activities ===");
        for (int i = 0; i < activityCount; i++)
        {
            activities[i].PrintInfo();
        }
    }

/////////////////////YAZAN_START//////////////////////////////////
    // Show All Trainers
    public void ShowAllTrainers()
    {
        Console.WriteLine("=== All Trainers ===");
        for (int i = 0; i < trainerCount; i++)
        {
            trainers[i].PrintInfo();
        }
    }

    // Show All Bookings
    public void ShowAllBookings()
    {
        Console.WriteLine("=== All Bookings ===");
        for (int i = 0; i < bookingCount; i++)
        {
            bookings[i].PrintInfo();
        }
    }
/////////////////////YAZAN_END//////////////////////////////////
}

// A File maneger class that's read and get files lines
// A File maneger class that's read and get files lines
public class FileManager
{
    // A smpel function ro read files
    private string[] ReadFile(string fileName)
    {
        string path = $"./files/{fileName}";
        if (!File.Exists(path))
        {
            Console.WriteLine($"File {fileName} not found.");
            return new string[0];
        }

        return File.ReadAllLines(path);
    }

    public static void SaveMember(Member member)
    {
        string line = "";
        if (member is StandardMember sm)
        {
            line = $"{sm.Id};{sm.Name};{sm.Email};{sm.JoinDate};STANDARD;{sm.FreezeDaysUsed};0";
        }
        else if (member is PremiumMember pm)
        {
            line = $"{pm.Id};{pm.Name};{pm.Email};{pm.JoinDate};PREMIUM;{pm.HasPersonalTrainer};{pm.GuestPasses}";
        }
        File.AppendAllText("MEMBERS.TXT", line + Environment.NewLine);
    }

    public static void SaveActivity(Activity activity)
    {
        string line = "";
        if (activity is GroupClass gc)
        {
            line = $"{gc.Id};{gc.Name};{gc.DurationMinutes};{gc.Capacity};GROUP;{gc.InstructorName};{gc.DifficultyLevel}";
        }
        else if (activity is PersonalTrainingSession pt)
        {
            line = $"{pt.Id};{pt.Name};{pt.DurationMinutes};{pt.Capacity};PT;{pt.TrainerId};{pt.HourlyRate}";
        }
        File.AppendAllText("ACTIVITIES.TXT", line + Environment.NewLine);
    }

    // Gets all members of the members.tex file and there infos
    public void LoadMembers(FitnessClubSystem system)
    {
        string[] lines = ReadFile("MEMBERS.TXT"); // read members file

        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(';'); // separat between parts
            // give every part a value
            int id = int.Parse(parts[0]);
            string name = parts[1];
            string email = parts[2];
            string joinDate = parts[3];

            // if the member is standerd use StandardMember constructor to add it to the arry, and if premium use PremiumMember constructor
            if (parts[4] == "STANDARD")
            {
                int freezeDaysUsed = int.Parse(parts[5]);
                system.AddMember(new StandardMember(id, name, email, joinDate, freezeDaysUsed)); 
            }
            else if (parts[4] == "PREMIUM")
            {
                bool hasPersonalTrainer = bool.Parse(parts[5]);
                int guestPasses = int.Parse(parts[6]);
                system.AddMember(new PremiumMember(id, name, email, joinDate, hasPersonalTrainer, guestPasses));
            }
        }
    }

    // Gets all activities of the activities.tex file and there infos
    public void LoadActivities(FitnessClubSystem system)
    {
        string[] lines = ReadFile("ACTIVITIES.TXT"); // read activities file

        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(';'); // separat between parts
            // give every part a value
            int id = int.Parse(parts[0]);
            string name = parts[1];
            int durationMinutes = int.Parse(parts[2]);
            int capacity = int.Parse(parts[3]);

            // if the activity is group use GroupClass constructor to add it to the arry, and if PT use PersonalTrainingSession constructor
            if (parts[4] == "GROUP")
            {
                string instructorName = parts[5];
                string difficultyLevel = parts[6];
                system.AddActivity(new GroupClass(id, name, durationMinutes, capacity, instructorName, difficultyLevel));
            }
            else if (parts[4] == "PT")
            {
                int trainerId = int.Parse(parts[5]);
                double hourlyRate = double.Parse(parts[6]);
                system.AddActivity(new PersonalTrainingSession(id, name, durationMinutes, capacity, trainerId, hourlyRate));
            }
        }
    }

/////////////////////YAZAN_START//////////////////////////////////
    // Load Trainers from TRAINERS.TXT
    public void LoadTrainers(FitnessClubSystem system)
    {
        string[] lines = ReadFile("TRAINERS.TXT");

        for (int i = 0; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;
            string[] parts = lines[i].Split(';');
            int trainerId = int.Parse(parts[0]);
            string name = parts[1];
            string specialty = parts[2];
            double salary = double.Parse(parts[3]);

            system.AddTrainer(new Trainer(trainerId, name, specialty, salary));
        }
    }

    // Load Bookings from BOOKINGS.TXT
    public void LoadBookings(FitnessClubSystem system)
    {
        string[] lines = ReadFile("BOOKINGS.TXT");

        for (int i = 0; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;
            string[] parts = lines[i].Split(';');
            int bookingId = int.Parse(parts[0]);
            int memberId = int.Parse(parts[1]);
            int activityId = int.Parse(parts[2]);
            string date = parts[3];
            string status = parts[4];

            system.AddBooking(new Booking(bookingId, memberId, activityId, date, status));
        }
    }
    /////////////////////YAZAN_END//////////////////////////////////
    

    public void SaveTrainer(Trainer trainer)
    {
        string path = "./files/TRAINERS.TXT";

        string line = $"{trainer.TrainerId};{trainer.Name};{trainer.Specialty};{trainer.Salary}";

        File.AppendAllText(path, line + Environment.NewLine);
    }

    public void SaveBooking(Booking booking)
    {
        string path = "./files/BOOKINGS.TXT";

        string line = $"{booking.BookingId};{booking.MemberId};{booking.ActivityId};{booking.Date};{booking.Status}";

        File.AppendAllText(path, line + Environment.NewLine);
    }

}

// the main program class that runs the === fitness club system ===
class Program
{
    static void Main(string[] args)
    {
        // create the system and the file meneger objects
        FitnessClubSystem system = new FitnessClubSystem();
        FileManager fileManager = new FileManager();

        // load members and activities from there files
        fileManager.LoadMembers(system);
        fileManager.LoadActivities(system);

/////////////////////YAZAN_START//////////////////////////////////
        fileManager.LoadTrainers(system);
        fileManager.LoadBookings(system);
/////////////////////YAZAN_END//////////////////////////////////

        try
        {
            // the main user menu
            Console.WriteLine("What do you want to see?");
            Console.WriteLine("1- Show all members");
            Console.WriteLine("2- Show all Activities");
            Console.WriteLine("3- Show all Trainers");
            Console.WriteLine("4- Show all Bookings");
            Console.WriteLine("5- Add new member");
            Console.WriteLine("6- Add new activity");
            Console.WriteLine("7- Add new trainer");
            Console.WriteLine("8- Add new booking");
            Console.WriteLine("\n>> ");

            string userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                system.ShowAllMembers();
            }
            else if (userChoice == "2")
            {
                system.ShowAllActivities();
            }
            else if (userChoice == "3")
            {
                system.ShowAllTrainers();
            }
            else if (userChoice == "4")
            {
                system.ShowAllBookings();
            }
            else if (userChoice == "5")
            {
                system.Addmemberinteractivite();
            }
            else if (userChoice == "6")
            {
                system.AddActivityInteraactive();
            }
            else if (userChoice == "7")
            {
                system.AddTrainerFromUser(fileManager);
            }
            else if (userChoice == "8")
            {
                system.AddBookingFromUser(fileManager);
            }
            else
            {
                Console.WriteLine("Wrong Number");
            }
        }
        catch (Exception exception) // exception to catch errors
        {
            Console.WriteLine("Error: " + exception);
        }
    }
}