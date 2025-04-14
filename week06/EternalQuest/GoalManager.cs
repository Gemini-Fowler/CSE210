using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuestApp
{
    class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();

        public void CreateGoal()
        {
            Console.WriteLine("Select Goal Type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");

            string choice = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();

            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            Console.Write("Enter point value: ");
            int points = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;

                case "2":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;

                case "3":
                    Console.Write("Enter target count: ");
                    int targetCount = int.Parse(Console.ReadLine());

                    Console.Write("Enter bonus points: ");
                    int bonusPoints = int.Parse(Console.ReadLine());

                    _goals.Add(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                    break;
            }
        }

        public void ListGoals()
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
            }
        }

        public int RecordEvent()
        {
            ListGoals();
            Console.Write("Which goal did you accomplish? ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < _goals.Count)
            {
                return _goals[index].RecordEvent();
            }

            Console.WriteLine("Invalid selection.");
            return 0;
        }

        public void SaveGoals(string filename)
        {
            List<string> lines = new List<string>();
            foreach (var goal in _goals)
            {
                lines.Add(goal.Serialize());
            }
            File.WriteAllLines(filename, lines);
        }

        public void LoadGoals(string filename)
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                string type = parts[0];

                if (type == "SimpleGoal")
                {
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                }
                else if (type == "ChecklistGoal")
                {
                    _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                                 int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                }
            }
        }

        public void SaveScore(string filename, int score)
        {
            File.WriteAllText(filename, score.ToString());
        }

        public int LoadScore(string filename)
        {
            return int.Parse(File.ReadAllText(filename));
        }
    }
}
