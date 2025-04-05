class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        name = "Breathing";
        description = "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath.";
    }

    protected override void PerformActivity()
    {
        int elapsed = 0;
        while (elapsed < duration)
        {
            Console.Write("Breathe in... ");
            Countdown(4);
            elapsed += 4;
            if (elapsed >= duration) break;

            Console.Write("Breathe out... ");
            Countdown(4);
            elapsed += 4;
        }
    }
}
