using System;
using System.Collections.Generic;
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

        try
        {
            // the main user menu
            Console.WriteLine("What do you want to see?");
            Console.WriteLine("1- Show all members");
            Console.WriteLine("2- Show all Activities");
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