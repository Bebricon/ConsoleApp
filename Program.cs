using System;
using System.Collections.Generic;

abstract class Student
{
    public string Name { get; set; }
    public int Age { get; set; }

    public abstract void DisplayInfo();
}
class StudentViewer : Student
{
    public override void DisplayInfo()
    {
        Console.WriteLine("Student Name: " + Name);
        Console.WriteLine("Student Age: " + Age);
    }
}
class StudentEditor : Student
{
    public override void DisplayInfo()
    {
        Console.WriteLine("Editing Student Info");
        Console.WriteLine("Current Name: " + Name);
        Console.WriteLine("Current Age: " + Age);

        Console.Write("Enter new Name: ");
        Name = Console.ReadLine();

        Console.Write("Enter new Age: ");
        Age = Convert.ToInt32(Console.ReadLine());
    }
}
class StudentGroup
{
    public string GroupName { get; set; }
    public List<Student> Students { get; set; }
    public string Monitor { get; set; }

    public void DisplayGroupInfo()
    {
        Console.WriteLine("Group Name: " + GroupName);
        Console.WriteLine("Group Monitor: " + Monitor);
        Console.WriteLine("Students in the group:");
        foreach (var student in Students)
        {
            student.DisplayInfo();
        }
    }
}

class Program
{
    static void Main()
    {
        StudentViewer viewer = new StudentViewer { Name = "Alice", Age = 20 };
        StudentEditor editor = new StudentEditor { Name = "Bob", Age = 22 };

        Console.WriteLine("Viewing Student Info:");
        viewer.DisplayInfo();

        Console.WriteLine("\nEditing Student Info:");
        editor.DisplayInfo();

        StudentGroup group = new StudentGroup
        {
            GroupName = "CS101",
            Monitor = "Charlie",
            Students = new List<Student> { viewer, editor }
        };

        Console.WriteLine("\nGroup Info:");
        group.DisplayGroupInfo();
    }
}