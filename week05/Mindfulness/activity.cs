using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    protected string name;
    protected string description;
    protected int duration;

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"--- {name} Activity ---");
        Console.WriteLine(description);
        Console.Write("\nHow many seconds would you like to do this activity? ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Spinner(3);
        PerformActivity();
        EndMessage();
    }

    protected abstract void PerformActivity();

    protected void EndMessage()
    {
        Console.WriteLine("\nWell done!");
        Spinner(2);
        Console.WriteLine($"You have completed the {name} activity for {duration} seconds.");
        Spinner(3);
    }

    protected void Spinner(int seconds)
    {
        string[] spinner = { "/", "-", "\\", "|" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
        Console.WriteLine();
    }
}
