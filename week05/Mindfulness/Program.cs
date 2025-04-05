// Extra Feature Added:
// This program tracks how many times each activity is completed during a session
// and displays session statistics when the user selects option 4 in the menu.
class Program
{
    static void Main(string[] args)
    {
        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Show Session Stats");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option: ");

            string input = Console.ReadLine();
            Activity activity = null;

            switch (input)
            {
                case "1":
                    activity = new BreathingActivity();
                    breathingCount++;
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    reflectionCount++;
                    break;
                case "3":
                    activity = new ListingActivity();
                    listingCount++;
                    break;
                case "4":
                    Console.WriteLine("\n--- Session Stats ---");
                    Console.WriteLine($"Breathing activities completed: {breathingCount}");
                    Console.WriteLine($"Reflection activities completed: {reflectionCount}");
                    Console.WriteLine($"Listing activities completed: {listingCount}");
                    Console.WriteLine("\nPress Enter to return to the menu.");
                    Console.ReadLine();
                    continue;
                case "5":
                    Console.WriteLine("Thank you for using the mindfulness app. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    Thread.Sleep(1500);
                    continue;
            }

            activity.Start();
        }
    }
}
