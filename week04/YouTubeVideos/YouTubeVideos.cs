using System;
using System.Collections.Generic;

class Comment
{
    public string Name { get; }
    public string Text { get; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    private List<Comment> comments = new List<Comment>();
    private static Random random = new Random();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(string name, string text)
    {
        comments.Add(new Comment(name, text));
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    private void DisplayCreativeMessage()
    {
        string[] creativeMessages = {
            "Keep coding, keep creating!",
            "Did you know? Abstraction is a powerful tool in OOP!",
            "Tip: Always comment your code for clarity.",
            "Fun Fact: Great code is its own documentation!"
        };

        int index = random.Next(creativeMessages.Length);
        Console.WriteLine("Creative Tip: " + creativeMessages[index]);
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");

        foreach (var comment in comments)
        {
            Console.WriteLine($"- {comment.Name}: {comment.Text}");
        }

        DisplayCreativeMessage();

        Console.WriteLine(new string('-', 40));
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Tutorial", "Code Academy", 600);
        video1.AddComment("Alice", "Great tutorial!");
        video1.AddComment("Bob", "Very helpful, thanks.");
        video1.AddComment("Charlie", "Can you cover classes in more detail?");

        Video video2 = new Video("Learn Python", "Tech Guru", 720);
        video2.AddComment("Dave", "Awesome content!");
        video2.AddComment("Eve", "Clear and concise explanation.");
        video2.AddComment("Frank", "Looking forward to more videos!");

        Video video3 = new Video("Java Basics", "Programming Hub", 540);
        video3.AddComment("Grace", "Helped me understand OOP better.");
        video3.AddComment("Heidi", "Well-explained concepts.");
        video3.AddComment("Ivan", "I was struggling with Java, but this helped!");

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
