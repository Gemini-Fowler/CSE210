using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Culligan";
        job1._jobTitle = "Water Delivery Driver";
        job1._startYear = 2022;
        job1._endYear = 2025;

        Job job2 = new Job();
        job2._company = "Subway";
        job2._jobTitle = "Sandwich Artist";
        job2._startYear = 2021;
        job2._endYear = 2022;

        Resume myResume = new Resume();
        myResume._name = "Gemini Fowler";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}