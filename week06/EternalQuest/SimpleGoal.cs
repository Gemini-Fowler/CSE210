namespace EternalQuestApp
{
    class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points, bool isComplete = false)
            : base(name, description, points)
        {
            _isComplete = isComplete;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return Points;
            }
            return 0;
        }

        public override bool IsComplete() => _isComplete;

        public override string GetDetails() => $"[ {(IsComplete() ? 'X' : ' ')} ] {Name} - {Description}";

        public override string Serialize() =>
            $"SimpleGoal|{Name}|{Description}|{Points}|{_isComplete}";
    }
}
