using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // ------------------- BONUS FEATURES -------------------
            // Added celestial-themed leveling system based on points:
            // Users gain levels like "Moonlit Seeker", "Galactic Sage", etc.
            // Encourages engagement by giving titles as you progress.
            // -------------------------------------------------------

            GoalManager goalManager = new GoalManager();
            int userScore = 0;

            // Load existing data if available
            if (File.Exists("goals.txt"))
            {
                goalManager.LoadGoals("goals.txt");
                userScore = goalManager.LoadScore("score.txt");
            }

            while (true)
            {
                Console.WriteLine("\n===== Eternal Quest Menu =====");
                Console.WriteLine($"Score: {userScore}");
                Console.WriteLine($"Level: {LevelManager.GetLevelName(userScore)}");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Save and Quit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        goalManager.CreateGoal();
                        break;

                    case "2":
                        goalManager.ListGoals();
                        break;

                    case "3":
                        int earnedPoints = goalManager.RecordEvent();
                        userScore += earnedPoints;
                        Console.WriteLine($"You earned {earnedPoints} points!");
                        Console.WriteLine($"New Score: {userScore}");
                        Console.WriteLine($"New Level: {LevelManager.GetLevelName(userScore)}");
                        break;

                    case "4":
                        goalManager.SaveGoals("goals.txt");
                        goalManager.SaveScore("score.txt", userScore);
                        Console.WriteLine("Progress saved. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
