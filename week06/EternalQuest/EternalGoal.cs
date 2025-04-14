namespace EternalQuestApp
{
    class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override int RecordEvent() => Points;

        public override bool IsComplete() => false;

        public override string GetDetails() => $"[∞] {Name} - {Description}";

        public override string Serialize() =>
            $"EternalGoal|{Name}|{Description}|{Points}";
    }
}
