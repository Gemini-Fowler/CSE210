namespace EternalQuestApp
{
    class ChecklistGoal : Goal
    {
        public int TargetCount { get; }
        public int BonusPoints { get; }
        public int CurrentCount { get; private set; }

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int currentCount = 0)
            : base(name, description, points)
        {
            TargetCount = targetCount;
            BonusPoints = bonusPoints;
            CurrentCount = currentCount;
        }

        public override int RecordEvent()
        {
            if (IsComplete()) return 0;

            CurrentCount++;
            int totalPoints = Points;

            if (IsComplete())
            {
                totalPoints += BonusPoints;
            }

            return totalPoints;
        }

        public override bool IsComplete() => CurrentCount >= TargetCount;

        public override string GetDetails() =>
            $"[ {(IsComplete() ? 'X' : ' ')} ] {Name} - {Description} (Completed {CurrentCount}/{TargetCount})";

        public override string Serialize() =>
            $"ChecklistGoal|{Name}|{Description}|{Points}|{TargetCount}|{BonusPoints}|{CurrentCount}";
    }
}
