using System;
using System.Collections.Generic;
using System.IO;

public class Member
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string JoinDate { get; set; } = "";
    public string Type { get; set; } = "";
    public string Field5 { get; set; } = "";
    public int Field6 { get; set; }

    public override string ToString()
    {
        return Id + "- " + Name + " | " + Email + " | " + JoinDate
             + " | " + Type + " | " + Field5 + " | " + Field6;
    }
}

class Program
{
    static void Main()
    {
        string path = "Members.txt";

        if (!File.Exists(path))
        {
            Console.WriteLine("الملف غير موجود: " + path);
            return;
        }

        string[] lines = File.ReadAllLines(path);
        List<Member> members = new List<Member>();

        for (int i = 0; i < lines.Length; i++)
        {
            int lineNumber = i + 1;
            string line = lines[i].Trim();

            if (line.Length == 0)
                continue;

            string[] parts = line.Split(';');

            try
            {
                Member m = new Member();
                m.Id       = int.Parse(parts[0].Trim());
                m.Name     = parts[1].Trim();
                m.Email    = parts[2].Trim();
                m.JoinDate = parts[3].Trim();
                m.Type     = parts[4].Trim();
                m.Field5   = parts[5].Trim();
                m.Field6   = int.Parse(parts[6].Trim());

                members.Add(m);
            }
            catch (Exception exception)
            {
                Console.WriteLine(":السطر " + lineNumber + " غير صالح: " + exception.Message);
            }
        }

        Console.WriteLine();
        Console.WriteLine("تم تحميل " + members.Count + " سجل:");
        Console.WriteLine();

        for (int i = 0; i < members.Count; i++)
        {
            Console.WriteLine(members[i]);
        }
    }
}